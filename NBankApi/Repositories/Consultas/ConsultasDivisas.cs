using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Models.DataBase;
using NBankApi.Models.DbContext;

namespace NBankApi.Repositories.Consultas
{
    public class ConsultasDivisas
    {
        private readonly DbContextNBank _db;
        public ConsultasDivisas (DbContextNBank db)
        {
            _db = db;
        }
        public List<Currencys> DivisasEnBase()
        {
            return _db.Divisas.ToList();
        }
        public Currencys DivisaId(int id_money)
        {
            return _db.Divisas.FirstOrDefault(x => x.id == id_money);
        }
    }
}