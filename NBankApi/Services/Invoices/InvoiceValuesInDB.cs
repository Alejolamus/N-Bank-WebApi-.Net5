using NBankApi.Dtos;
using NBankApi.Models.DataBase;
using NBankApi.Models.myEnums;
using NBankApi.Repositories.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Services.Invoices
{
    public class InvoiceValuesInDB
    {
        private readonly ConsultasCreditos _findCredits;
        private readonly ConsultasClientes _findClients;
        private readonly ConsultasDivisas _findCurrencys;
        public InvoiceValuesInDB(ConsultasCreditos findCredits,
                                 ConsultasClientes findClient,
                                 ConsultasDivisas findCurrency)
        {
            _findCredits = findCredits;
            _findClients = findClient;
            _findCurrencys = findCurrency;
        }
        public CreditInvoiceValues valoresDeFactura(int idCredit)
        {
            Credits credito = _findCredits.ConsultaCreditoIdCredit(idCredit);
            Clients cliente = _findClients.ClientePorId(credito.user_id);
            Currencys divisa = _findCurrencys.DivisaId(credito.id_currency);
            decimal interes = 0m;
            switch (credito.payment_frequency)
            {
                case Frecuencia.frecuencia.weekly:
                    decimal valorSum1 = credito.outstanding_balance * 0.006m;
                    interes = interes + valorSum1;
                    break;
                case Frecuencia.frecuencia.biweekly:
                    decimal valorSum2 = credito.outstanding_balance * 0.0012m;
                    interes = interes + valorSum2;
                    break;
                default:
                    decimal valorSum3 = credito.outstanding_balance * 0.0024m;
                    interes = interes + valorSum3;
                    break;
            }
            CreditInvoiceValues valores = new CreditInvoiceValues(cliente.name,
                                                                  cliente.document_type,
                                                                  cliente.document,
                                                                  credito.id,
                                                                  credito.value,
                                                                  credito.installment_count,
                                                                  credito.PaidInstallament,
                                                                  credito.outstanding_balance,
                                                                  credito.installamentAmount,
                                                                  credito.installamentAmount - interes,
                                                                  interes,
                                                                  credito.insurancePremium,
                                                                  credito.overdue_balance,
                                                                  divisa.symbol,
                                                                  cliente.email,
                                                                  credito.next_cutoff_date.AddDays(15));
            return valores;
        }
    }
}

    