using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Models.DataBase;
using NBankApi.Models.DbContext;

namespace NBankApi.Repositories.Consultas
{
    public class ConsultaMunicipios
    {
        private readonly DbContextNBank _db;
        public ConsultaMunicipios(DbContextNBank db)
        {
            _db = db;
        }
        public bool ExistMunicipios()
        {
            return _db.Municipios.Any();
        }
        public List<MunicipalityCol> listMunicipios()
        {
            return _db.Municipios.ToList();
        }
    }
}
