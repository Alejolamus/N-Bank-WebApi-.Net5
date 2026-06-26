using NBankApi.Models.myEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Models.PaymentModels
{
    public class ModelDual : ModelCollet
    {
        public decimal valueInvoice { get; set; }
        public decimal valueCapital { get; set; }
        public ModelDual(string AuthCode, string NumInvoice, int IdParther,
                         DateTime ColletDate, TipoDePago.tipo_pago Type, decimal ValueInvoice,
                         decimal ValueCapital)
                         : base(AuthCode, NumInvoice, IdParther, ColletDate, Type)
        {
            valueInvoice = ValueInvoice;
            valueCapital = ValueCapital;
        }
    }
}