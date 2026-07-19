using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Models.DbContext;
using NBankApi.Models.DataBase;
using NBankApi.Models.myEnums;

namespace NBankApi.Repositories.Consultas
{
    public class ConsultasMiembros
    {
        private readonly DbContextNBank _db;
        public ConsultasMiembros (DbContextNBank db)
        {
            _db = db;
        }
        //busca un ientro por id
        public NBankMembers BusquedaMienbroIdCargo(int idMember, nBankMembersRoles.roles Rol)
        {
            return _db.Miembros.FirstOrDefault(k => k.id == idMember && k.rol == Rol);
        }
    }
}
