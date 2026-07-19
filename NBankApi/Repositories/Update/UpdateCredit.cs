using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Models.DataBase;
using NBankApi.Models.DbContext;

namespace NBankApi.Repositories.Update
{
    public class UpdateCredit
    {
        private readonly DbContextNBank _db;
        public UpdateCredit (DbContextNBank db)
        {
            _db = db;
        }
        //actualiza un credito por su id cambiado el saldo pendiente
        public void UpdateOutadingBalance(int idCredit, decimal valor)
        {
            Credits credito = _db.Creditos.FirstOrDefault(x => x.id == idCredit);
            credito.outstanding_balance -= valor;
        }
    }
}