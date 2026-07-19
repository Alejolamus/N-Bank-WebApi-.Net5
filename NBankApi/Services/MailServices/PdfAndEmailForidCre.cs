using NBankApi.Dtos;
using NBankApi.Models.DataBase;
using NBankApi.Models.InvoiceModels;
using NBankApi.Models.InvoiceModels.MailModel;
using NBankApi.Repositories.Consultas;
using NBankApi.Services.Invoices;
using NBankApi.Services.Invoices.QuestPdfCode;
using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Services.MailServices
{
    public class PdfAndEmailForidCre
    {
        private readonly ConsultasCreditos _buscarCreditos;
        private readonly ConsultasClientes _buscarClientes;
        private readonly ModelGenerator _generadorDeModelo;
        public PdfAndEmailForidCre (ConsultasCreditos buscarCreditos,
                                    ConsultasClientes buscarClientes,
                                    ModelGenerator generadorDeModelo)
        {
            _buscarCreditos = buscarCreditos;
            _buscarClientes = buscarClientes;
            _generadorDeModelo = generadorDeModelo;
        }
        //metodo para buscar credito y realizar en envio al cliente al cual se encuentra asociado
        public DataInvoice CorreoFacturaPorIdCredit(int idcredito)
        {
            CreditInvoiceModel model = _generadorDeModelo.GenerarModeloFactura(idcredito);
            InvoiceDocument pdf = new InvoiceDocument(model);
            Credits credito = _buscarCreditos.ConsultaCreditoIdCredit(idcredito);
            Clients client = _buscarClientes.ClientePorId(credito.user_id);
            byte[] pdfBytes = pdf.GeneratePdf();
            MemoryStream stream = new MemoryStream(pdfBytes);
            MailModel modeloCorreo = new MailModel(client.email, stream);
            SendMailMethod mensajeria = new SendMailMethod();
            mensajeria.SendMail(modeloCorreo);
            DataInvoice dataInvoice = new DataInvoice(null, idcredito, model.Credito.TotalPago, model.Credito.FechaPago,
                                                      model.Credito.ValorCuota, model.DetallePago.Seguro,
                                                      model.Credito.SaldoMora + model.DetallePago.InteresMora);
            return dataInvoice;
        }
    }
}