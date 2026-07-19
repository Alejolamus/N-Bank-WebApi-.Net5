using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Models.DataBase;
using NBankApi.Models.DbContext;

namespace NBankApi.Repositories.Add
{
    public class AddFinancialStatus
    {
        private readonly DbContextNBank _db;
        public AddFinancialStatus(DbContextNBank db)
        {
            _db = db;
        }
        //ingresa registro a la tabla estado financiero, sin retorno
        public void AddEstadidoFinanciero(int IdInvoice, decimal VSeguro, decimal VCuota, decimal VMora)
        {
            FinancialStatus estado = new FinancialStatus()
            {
                idInvoice = IdInvoice,
                seguro = VSeguro,
                cuota = VCuota,
                mora = VMora
            };
            _db.EstadosFinancieros.Add(estado);
            _db.SaveChanges();
        }
    }
}
