using NBankApi.Dtos;
using NBankApi.Models.InvoiceModels;
using NBankApi.Models.myEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Services.Invoices
{
    public class ModelGenerator
    {
        private readonly InvoiceValuesInDB _valuesForInvoiceDb;
        public ModelGenerator(InvoiceValuesInDB valuesForInvoiceDb)
        {
            _valuesForInvoiceDb = valuesForInvoiceDb;
        }
        public CreditInvoiceModel GenerarModeloFactura(int idCredit)
        {
            CreditInvoiceValues datosDB = _valuesForInvoiceDb.valoresDeFactura(idCredit);
            string documento = "";
            switch (datosDB.tipoDocumento)
            {
                case typedocument.typedocu.Cc:
                    documento = $"c.c {datosDB.numeroDocumento}";
                    break;
                case typedocument.typedocu.Ce:
                    documento = $"c.e {datosDB.numeroDocumento}";
                    break;
                default:
                    documento = $"p {datosDB.numeroDocumento}";
                    break;
            }

            InvoiceClientInfo clientInformation = new InvoiceClientInfo(datosDB.clientName,
                                                                    documento,
                                                                    datosDB.correo);
            string coutaActACuotaTot = $"{datosDB.cuotasPagadas} / {datosDB.cantidadCuotas}";
            decimal interesMora = datosDB.saldoMora * 0.03m;
            decimal TotalPago = datosDB.seguroValue + datosDB.cuota + datosDB.saldoMora + interesMora;
            InvoiceCreditInfo cretidInformation = new InvoiceCreditInfo(datosDB.IdCredit.ToString("D7"),
                                                                       datosDB.totalValueCredit,
                                                                       coutaActACuotaTot,
                                                                       datosDB.FechaPago,
                                                                       datosDB.saldoCredito,
                                                                       datosDB.saldoMora,
                                                                       datosDB.cuota,
                                                                       datosDB.simboloDeMoneda,
                                                                       TotalPago
                                                                       );
            InvoicePaymentBreakdown paymentBreakdown = new InvoicePaymentBreakdown(datosDB.abonoCapital,
                                                                                   datosDB.interes,
                                                                                   datosDB.seguroValue,
                                                                                   datosDB.saldoMora);
            CreditInvoiceModel modeloFactura = new CreditInvoiceModel(clientInformation,
                                                                      cretidInformation,
                                                                      paymentBreakdown);
            return modeloFactura;

        }

    }
}