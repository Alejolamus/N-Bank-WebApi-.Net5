using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Models.InvoiceModels
{
    public class CreditInvoiceModel
    {
        public InvoiceClientInfo Cliente { get; set; }

        public InvoiceCreditInfo Credito { get; set; }

        public InvoicePaymentBreakdown DetallePago { get; set; }
        public CreditInvoiceModel(InvoiceClientInfo cliente,
                                  InvoiceCreditInfo credito,
                                  InvoicePaymentBreakdown detallePago)
        {
            Cliente = cliente;
            Credito = credito;
            DetallePago = detallePago;
        }
    }
}