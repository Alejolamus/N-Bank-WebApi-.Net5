using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Models.DataBase;
using NBankApi.Models.DbContext;

namespace NBankApi.Repositories.Consultas
{
    public class ConsultasAliados
    {
        private readonly DbContextNBank _db;
        public ConsultasAliados (DbContextNBank db)
        {
            _db = db;
        }
        public List<Partners> AliadosDeCobros()
        {
            return _db.Aliados.ToList();
        }
        public Partners Aliado(int idParther)
        {
            return _db.Aliados.FirstOrDefault(x => x.id == idParther);
        }
    }
}