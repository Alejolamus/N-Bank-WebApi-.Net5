using NBankApi.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Models.DbContext;

namespace NBankApi.Repositories.Consultas
{
    public class ConsultasEstadosFinancieros
    {
        private readonly DbContextNBank _db;
        public ConsultasEstadosFinancieros(DbContextNBank db)
        {
            _db = db;
        }
        //retorna un estado financiero por medio de su id
        public FinancialStatus EstadoFactura(int idFactura)
        {
            return _db.EstadosFinancieros.FirstOrDefault(x => x.idInvoice == idFactura);
        }
    }
}