using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Models.InvoiceModels
{
    public class InvoicePaymentBreakdown
    {
        public decimal Capital { get; set; }

        public decimal Interes { get; set; }

        public decimal Seguro { get; set; }

        public decimal InteresMora { get; set; }
        public InvoicePaymentBreakdown(decimal capital,
                                       decimal interes,
                                       decimal seguro,
                                       decimal mora)
        {
            Capital = capital;
            Interes = interes;
            Seguro = seguro;
            InteresMora = mora;
        }

    }
}