using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Dtos
{
    public class DataInvoice
    {
        public string numInvoice { get; set; }
        public int idCredito { get; set; }
        public decimal value { get; set; }
        public DateTime paymentDate { get; set; }
        public decimal cuota { get; set; }
        public decimal seguro { get; set; }
        public decimal mora { get; set; }
        public DataInvoice(string NumInvoice,
                           int IdCredit,
                           decimal Valeue,
                           DateTime PaymentDate,
                           decimal Cuota,
                           decimal Seguro,
                           decimal Mora)
        {
            numInvoice = NumInvoice;
            idCredito = IdCredit;
            value = Valeue;
            paymentDate = PaymentDate;
            cuota = Cuota;
            seguro = Seguro;
            mora = Mora;
        }
    }
}
