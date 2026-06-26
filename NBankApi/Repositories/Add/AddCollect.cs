using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Models.DataBase;
using NBankApi.Models.DbContext;
using NBankApi.Models.myEnums;

namespace NBankApi.Repositories.Add
{
    public class AddCollect
    {
        private readonly DbContextNBank _db;
        public AddCollect(DbContextNBank db)
        {
            _db = db;
        }
        public void AddRecaudo(int idFactura,
                               decimal recaudo,
                               DateTime fechapago,
                               TipoDePago.tipo_pago tipoDePago,
                               int idInstitucionFinanciera,
                               string codigoAutorizacion)
        {
            Collects Recaudo = new Collects()
            {
                idInvoice = idFactura,
                collection = recaudo,
                paymentDate = fechapago,
                paymentType = tipoDePago,
                idPartner = idInstitucionFinanciera,
                AuthorizationCode = codigoAutorizacion
            };
            _db.Recaudos.Add(Recaudo);
            _db.SaveChanges();
        }
    }
}