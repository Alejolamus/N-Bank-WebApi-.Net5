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
        //lista las facturas asociadas a un credito por medio de la foranea id credito
        public List<Invoice> FacturasCredito(int id_credito)
        {
            return _db.Facturas.Where(x => x.id_credit == id_credito).ToList();
        }
        //retorna una factura por su id
        public Invoice FacturaParticularId(int id_factura)
        {
            return _db.Facturas.FirstOrDefault(x => x.id == id_factura);
        }
        //retorna una factura por medio de su numero
        public Invoice FacturaParticularNum(string numFactura)
        {
            return _db.Facturas.FirstOrDefault(x => x.invoice_number == numFactura);
        }
    }
}