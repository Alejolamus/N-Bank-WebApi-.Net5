using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Models.InvoiceModels
{
    public class InvoiceCreditInfo
    {
        public string NumeroCredito { get; set; }
        public decimal ValorCredito { get; set; }

        public string CuotaActVsTotalCuotas { get; set; }

        public DateTime FechaPago { get; set; }

        public decimal SaldoPendiente { get; set; }
        public decimal SaldoMora { get; set; }

        public decimal ValorCuota { get; set; }
        public string SimboloMoneda { get; set; }
        public decimal TotalPago { get; set; }
        public InvoiceCreditInfo(string numCredit,
                                 decimal ValueCredit,
                                 string CouVsTot,
                                 DateTime fechaPago,
                                 decimal pendiente,
                                 decimal mora,
                                 decimal cuota,
                                 string simbolo,
                                 decimal pagototal)
        {
            NumeroCredito = numCredit;
            ValorCredito = ValueCredit;
            CuotaActVsTotalCuotas = CouVsTot;
            FechaPago = fechaPago;
            SaldoPendiente = pendiente;
            SaldoMora = mora;
            ValorCuota = cuota;
            SimboloMoneda = simbolo;
            TotalPago = pagototal;
        }
    }
}
