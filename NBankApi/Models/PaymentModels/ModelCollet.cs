using NBankApi.Models.myEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Models.PaymentModels
{
    public class ModelCollet
    {
        public string authCode { get; set; }
        public string numInvoice { get; set; }
        public int idParther { get; set; }
        public DateTime colletDate { get; set; }
        public TipoDePago.tipo_pago type { get; set; }
        public ModelCollet(string AuthCode, string NumInvoice, int Parther, DateTime ColletDate, TipoDePago.tipo_pago Type)
        {
            authCode = AuthCode;
            numInvoice = NumInvoice;
            idParther = Parther;
            colletDate = ColletDate;
            type = Type;
        }
    }
}