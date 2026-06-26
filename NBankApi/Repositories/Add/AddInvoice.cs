using NBankApi.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Models.DbContext;


namespace NBankApi.Repositories.Add
{
    public class AddInvoice
    {
        private readonly DbContextNBank _db;
        public AddInvoice(DbContextNBank db)
        {
            _db = db;
        }
        public Invoice AddFactura(string numero_factura,
                               int id_credito,
                               decimal cobro,
                               DateTime fecha_cobro)
        {
            Invoice factura = new Invoice()
            {
                invoice_number = numero_factura,
                id_credit = id_credito,
                current_balance = cobro,
                on_time_payment = fecha_cobro
            };
            _db.Facturas.Add(factura);
            _db.SaveChanges();
            return factura;
        }
    }
}