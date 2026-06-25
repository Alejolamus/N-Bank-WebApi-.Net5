using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using NBankApi.Repositories.Consultas;
using NBankApi.Models.DataBase;
using NBankApi.Models.myEnums;

namespace NBankApi.Services.JwtServices

{
    public class ValidarToken
    {
        private readonly ConsultasAliados _consultarAliados;
        private readonly ConsultasClientes _consultarClientes;
        private readonly ConsultasMiembros _consultarMiembros;
        public ValidarToken(ConsultasAliados consultasAliados, 
                            ConsultasClientes consultasClientes, 
                            ConsultasMiembros consultasMiembros)
        {
            _consultarAliados = consultasAliados;
            _consultarClientes = consultasClientes;
            _consultarMiembros = consultasMiembros;
        }
        public dynamic ValidacionDeToken(ClaimsIdentity identity)
        {
            try
            {
                if (identity.Claims.Count() == 2)
                {
                    return false;
                }
                else
                {
                    string idClaim = identity.Claims.FirstOrDefault(k => k.Type == "id").Value;
                    string rollClaim = identity.Claims.FirstOrDefault(k => k.Type == "Rol").Value;
                    string[] roles = { "Client", "Pathner", "Member-atencion", "Member-asesor", "Member-Admin" };
                    if (roles.Contains(rollClaim))
                    {
                        switch (rollClaim)
                        {
                            case "Client":
                                if (int.TryParse(idClaim, out int idClaimClient))
                                {
                                    Clients cliente = _consultarClientes.ClientePorId(idClaimClient);
                                }
                                else
                                {
                                    //f
                                }
                                break;
                            case "Partner":
                                if (int.TryParse(idClaim, out int idClaimPartner))
                                {
                                    Partners aliado = _consultarAliados.Aliado(idClaimPartner);
                                }
                                    break;
                            case "Member-atencion":
                                if (int.TryParse(idClaim, out int idClaimAtention))
                                {
                                    NBankMembers AtencionCliente = _consultarMiembros.BusquedaMienbroIdCargo(idClaimAtention,
                                                                                                             nBankMembersRoles.roles.Atencion);
                                }
                                    break;
                            case "Member-asesor":
                                if (int.TryParse(idClaim, out int idClaimAsesor))
                                {
                                    NBankMembers Asesor = _consultarMiembros.BusquedaMienbroIdCargo(idClaimAsesor,
                                                                                                    nBankMembersRoles.roles.Asesor);
                                }
                                break;
                            default:
                                if (int.TryParse(idClaim, out int idClaimAdmin))
                                {
                                    NBankMembers Admin = _consultarMiembros.BusquedaMienbroIdCargo(idClaimAdmin,
                                                                                                   nBankMembersRoles.roles.Admin);
                                }
                                break;
                        }
                    }
                    else
                    {
                        //pailander
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
        }
    }
}
