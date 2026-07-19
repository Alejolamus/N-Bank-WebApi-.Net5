using NBankApi.Models.InvoiceModels;
using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Services.Invoices.QuestPdfCode
{
    public class HeaderCoponent
    {
        //encabezado de la factura recurre a un contenedor de datos
        public static void headerCoponent(
            QuestPDF.Infrastructure.IContainer container,
            CreditInvoiceModel model)
        {
            container.Column(column =>
            {
                column.Item().Text($"Credito: {model.Credito.NumeroCredito}");
                column.Item().Text($"Cliente: {model.Cliente.Nombre}");
                column.Item().Text($"Documento: {model.Cliente.Documento}");
                column.Item().Text($"Email: {model.Cliente.Correo}");
            });
        }
    }
}