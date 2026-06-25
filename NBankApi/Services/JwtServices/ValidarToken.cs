using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using NBankApi.Repositories.Consultas;
using NBankApi.Models.DataBase;
using NBankApi.Models.myEnums;
using NBankApi.Dtos;

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
        public JwtValidacionData ValidacionDeToken(ClaimsIdentity identity)
        {
            try
            {
                if (identity.Claims.Count() != 2)
                {
                    JwtValidacionData resp0 = new JwtValidacionData(null,
                                                                    null,
                                                                    false,
                                                                    "Token invalido");
                    return resp0;
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
                                    if (cliente != null)
                                    {
                                        JwtValidacionData resp1 = new JwtValidacionData(cliente.id,
                                                                                        RolesJwt.rolesJwt.cliente,
                                                                                        true,
                                                                                        "Token de cliente valido");
                                        return resp1;
                                    }
                                    else
                                    {
                                        JwtValidacionData resp2 = new JwtValidacionData(null,
                                                                                        null,
                                                                                        false,
                                                                                        "Token de cliente invalido");
                                        return resp2;
                                    }
                                }
                                else
                                {
                                    JwtValidacionData resp3 = new JwtValidacionData(null,
                                                                                   null,
                                                                                   false,
                                                                                   "Token de cliente invalido");
                                    return resp3;
                                }
                            case "Partner":
                                if (int.TryParse(idClaim, out int idClaimPartner))
                                {
                                    Partners aliado = _consultarAliados.Aliado(idClaimPartner);
                                    if (aliado != null)
                                    {
                                        JwtValidacionData resp4 = new JwtValidacionData(aliado.id,
                                                                                        RolesJwt.rolesJwt.cliente,
                                                                                        true,
                                                                                        "Token de aliado valido");
                                        return resp4;
                                    }
                                    else
                                    {
                                        JwtValidacionData resp5 = new JwtValidacionData(null,
                                                                                        null,
                                                                                        false,
                                                                                        "Token de aliado invalido");
                                        return resp5;
                                    }
                                }
                                else
                                {
                                    JwtValidacionData resp6 = new JwtValidacionData(null,
                                                                                    null,
                                                                                    false,
                                                                                    "Token de aliado invalido");
                                    return resp6;
                                }
                            case "Member-atencion":
                                if (int.TryParse(idClaim, out int idClaimAtention))
                                {
                                    NBankMembers AtencionCliente = _consultarMiembros.BusquedaMienbroIdCargo(idClaimAtention,
                                                                                                             nBankMembersRoles.roles.Atencion);
                                    if (AtencionCliente != null)
                                    {
                                        JwtValidacionData resp7 = new JwtValidacionData(AtencionCliente.id,
                                                                                        RolesJwt.rolesJwt.cliente,
                                                                                        true,
                                                                                        "Token de Atencion al cliente valido");
                                        return resp7;
                                    }
                                    else
                                    {
                                        JwtValidacionData resp8 = new JwtValidacionData(null,
                                                                                        null,
                                                                                        false,
                                                                                        "Token de Atencion al cliente invalido");
                                        return resp8;
                                    }
                                }
                                else
                                {
                                    JwtValidacionData resp9 = new JwtValidacionData(null,
                                                                                    null,
                                                                                    false,
                                                                                    "Token de Atencion al cliente invalido");
                                    return resp9;
                                }
                            case "Member-asesor":
                                if (int.TryParse(idClaim, out int idClaimAsesor))
                                {
                                    NBankMembers Asesor = _consultarMiembros.BusquedaMienbroIdCargo(idClaimAsesor,
                                                                                                    nBankMembersRoles.roles.Asesor);
                                    if (Asesor != null)
                                    {
                                        JwtValidacionData resp10 = new JwtValidacionData(Asesor.id,
                                                                                         RolesJwt.rolesJwt.cliente,
                                                                                         true,
                                                                                         "Token de Asesor valido");
                                        return resp10;
                                    }
                                    else
                                    {
                                        JwtValidacionData resp11 = new JwtValidacionData(null,
                                                                                         null,
                                                                                         false,
                                                                                         "Token de Asesor invalido");
                                        return resp11;
                                    }
                                }
                                else
                                {
                                    JwtValidacionData resp12 = new JwtValidacionData(null,
                                                                                     null,
                                                                                     false,
                                                                                     "Token de Asesor invalido");
                                    return resp12;
                                }
                            default:
                                if (int.TryParse(idClaim, out int idClaimAdmin))
                                {
                                    NBankMembers Admin = _consultarMiembros.BusquedaMienbroIdCargo(idClaimAdmin,
                                                                                                   nBankMembersRoles.roles.Admin);
                                    if (Admin != null)
                                    {
                                        JwtValidacionData resp13 = new JwtValidacionData(Admin.id,
                                                                                         RolesJwt.rolesJwt.cliente,
                                                                                         true,
                                                                                         "Token de Admin valido");
                                        return resp13;
                                    }
                                    else
                                    {
                                        JwtValidacionData resp14 = new JwtValidacionData(null,
                                                                                         null,
                                                                                         false,
                                                                                         "Token de Admin invalido");
                                        return resp14;
                                    }
                                }
                                else
                                {
                                    JwtValidacionData resp15 = new JwtValidacionData(null,
                                                                                     null,
                                                                                     false,
                                                                                     "Token de Admin invalido");
                                    return resp15;
                                }
                        }
                    }
                    else
                    {
                        JwtValidacionData resp16 = new JwtValidacionData(null,
                                                                         null,
                                                                         false,
                                                                         "Token invalido");
                        return resp16;
                    }
                }
            }
            catch (Exception ex)
            {
                JwtValidacionData resp17 = new JwtValidacionData(null,
                                                                 null,
                                                                 false,
                                                                 ex.Message);
                return resp17;
            }
        }
    }
}
