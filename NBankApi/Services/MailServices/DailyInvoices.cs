using NBankApi.Dtos;
using NBankApi.Repositories.Add;
using NBankApi.Repositories.Consultas;
using NBankApi.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Services.MailServices
{
    public class DailyInvoices
    {
        private readonly ConsultasCreditos _findCredits;
        private readonly AddInvoice _addInvoices;
        private readonly AddFinancialStatus _addFinancialStatus;
        private readonly PdfAndEmailForidCre _pdfAndEmail;
        public DailyInvoices(ConsultasCreditos findCredits,
                             AddInvoice addInvoices,
                             AddFinancialStatus addFinancialStatus,
                             PdfAndEmailForidCre pdfAndEmail)
        {
            _findCredits = findCredits;
            _addInvoices = addInvoices;
            _addFinancialStatus = addFinancialStatus;
            _pdfAndEmail = pdfAndEmail;
        }
        //metodo que busca todos los creditos con fecha de corte al dia de ejecucion, genera y envia factura
        public void SendDayliInvocices()
        {

            DateTime fecha = DateTime.Today;
            List<int> ids = _findCredits.CreditosConcorte(fecha);

            int contador = 1;
            foreach (int x in ids)
            {
                DataInvoice dataInvoice = _pdfAndEmail.CorreoFacturaPorIdCredit(x);
                string numFactura = $"{fecha}" + contador.ToString("D5");
                Invoice factura = _addInvoices.AddFactura(numFactura, 
                                                          dataInvoice.idCredito, 
                                                          dataInvoice.value, 
                                                          dataInvoice.paymentDate);
                _addFinancialStatus.AddEstadidoFinanciero(factura.id, 
                                                          dataInvoice.seguro,
                                                          dataInvoice.cuota, 
                                                          dataInvoice.mora);
            }
        }
    }
}