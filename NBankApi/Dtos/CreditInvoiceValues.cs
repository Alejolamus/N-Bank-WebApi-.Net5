using NBankApi.Models.myEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Dtos
{
    public class CreditInvoiceValues
    {
        public string clientName { get; set; }
        public typedocument.typedocu tipoDocumento { get; set; }
        public int numeroDocumento { get; set; }
        public int IdCredit { get; set; }
        public decimal totalValueCredit { get; set; }
        public int cantidadCuotas { get; set; }
        public int cuotasPagadas { get; set; }
        public decimal saldoCredito { get; set; }
        public decimal cuota { get; set; }
        public decimal abonoCapital { get; set; }
        public decimal interes { get; set; }
        public decimal seguroValue { get; set; }
        public decimal saldoMora { get; set; }
        public string simboloDeMoneda { get; set; }
        public string correo { get; set; }
        public DateTime FechaPago { get; set; }

        public CreditInvoiceValues(string Nombre,
                                   typedocument.typedocu TipoDocumento,
                                   int NumeroDocumento,
                                   int idCredito,
                                   decimal TotalValueCredit,
                                   int CantidadCuotas,
                                   int CuotasPagadas,
                                   decimal SaldoCredito,
                                   decimal Cuota,
                                   decimal AbonoCapital,
                                   decimal Interes,
                                   decimal SeguroValue,
                                   decimal SaldoMora,
                                   string simbolo,
                                   string mail,
                                   DateTime fechaPago
            )
        {
            clientName = Nombre;
            tipoDocumento = TipoDocumento;
            numeroDocumento = NumeroDocumento;
            IdCredit = idCredito;
            totalValueCredit = TotalValueCredit;
            cantidadCuotas = CantidadCuotas;
            cuotasPagadas = CuotasPagadas;
            saldoCredito = SaldoCredito;
            cuota = Cuota;
            abonoCapital = AbonoCapital;
            interes = Interes;
            seguroValue = SeguroValue;
            saldoMora = SaldoMora;
            simboloDeMoneda = simbolo;
            correo = mail;
            FechaPago = fechaPago;
        }
    }
}
