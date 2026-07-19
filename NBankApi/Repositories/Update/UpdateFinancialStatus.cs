using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Models.DbContext;
using NBankApi.Models.DataBase;

namespace NBankApi.Repositories.Update
{
    public class UpdateFinancialStatus
    {
        private readonly DbContextNBank _db;
        public UpdateFinancialStatus (DbContextNBank db)
        {
            _db = db;
        }
        //actualiza un estado financiero asociado a una factura
        public void UpdateValues(int idInvoice, decimal Seguro, decimal saldoR)
        {
            FinancialStatus estado = _db.EstadosFinancieros.FirstOrDefault(x => x.idInvoice == idInvoice);
            estado.seguro -= Seguro;
            if (saldoR > estado.cuota)
            {
                estado.cuota = 0;
                estado.mora -= (saldoR - estado.cuota);
            }
            else
            {
                estado.cuota -= saldoR;
            }
            _db.SaveChanges();
        }
    }
}