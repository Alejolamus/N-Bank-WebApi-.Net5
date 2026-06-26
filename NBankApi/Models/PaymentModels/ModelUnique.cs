using NBankApi.Models.myEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Models.PaymentModels
{
    public class ModelUnique : ModelCollet
    {
        public decimal value { get; set; }
        public ModelUnique(string AuthCode, string NumInvoice, int IdParther,
                           DateTime ColletDate, TipoDePago.tipo_pago Type, decimal Value)
                           : base(AuthCode, NumInvoice, IdParther, ColletDate, Type)
        {
            value = Value;
        }
    }
}