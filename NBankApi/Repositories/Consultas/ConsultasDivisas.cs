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
        //lista las monedas en base de datos
        public List<Currencys> DivisasEnBase()
        {
            return _db.Divisas.ToList();
        }
        //retorna un moneda por medio de su id
        public Currencys DivisaId(int id_money)
        {
            return _db.Divisas.FirstOrDefault(x => x.id == id_money);
        }
        //retorna un booleano que indica si existen registro en la tabla
        public bool ExistMonedas()
        {
            return _db.Divisas.Any();
        }
    }
}