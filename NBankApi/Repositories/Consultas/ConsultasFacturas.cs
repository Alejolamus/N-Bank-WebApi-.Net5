using NBankApi.Models.DataBase;
using NBankApi.Models.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Repositories.Consultas
{
    public class ConsultasFacturas
    {
        private readonly DbContextNBank _db;
        public ConsultasFacturas (DbContextNBank db)
        {
            _db = db;
        }
        public List<Invoice> FacturasCredito(int id_credito)
        {
            return _db.Facturas.Where(x => x.id_credit == id_credito).ToList();
        }
        public Invoice FacturaParticularId(int id_factura)
        {
            return _db.Facturas.FirstOrDefault(x => x.id == id_factura);
        }
        public Invoice FacturaParticularNum(string numFactura)
        {
            return _db.Facturas.FirstOrDefault(x => x.invoice_number == numFactura);
        }
    }
}