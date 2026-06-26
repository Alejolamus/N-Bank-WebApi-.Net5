using NBankApi.Models.InvoiceModels.MailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NBankApi.Services.MailServices
{
    public class SendMailMethod
    {
        public void SendMail(MailModel modelo)
        {

            Attachment archivo =
                new Attachment(
                    modelo.pdf,
                    "factura.pdf",
                    "application/pdf");

            MailMessage correo =
            new MailMessage();

            correo.From =
                new MailAddress(
                    "nbank.system@gmail.com");

            correo.To.Add(
                modelo.email);

            correo.Subject =
                "Factura de cobro";

            correo.Body =
                "Su factura fue generada.";
            correo.Attachments.Add(archivo);

            SmtpClient smtp =
                new SmtpClient(
                    "smtp.gmail.com",
                    587);

            smtp.Credentials =
                new NetworkCredential(
                    "nbank.system@gmail.com",
                    "APP_PASSWORD");

            smtp.EnableSsl = true;

            smtp.Send(correo);
        }
    }
}