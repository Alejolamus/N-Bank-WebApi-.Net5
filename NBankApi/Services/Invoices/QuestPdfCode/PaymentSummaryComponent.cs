using NBankApi.Models.InvoiceModels;
using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Services.Invoices.QuestPdfCode
{
    public class PaymentSummaryComponent
    {
        //seccion de detalle de pago usa tablas dentro de un contenedor
        public static void paymentSummaryComponent(QuestPDF.Infrastructure.IContainer container,
            CreditInvoiceModel model)
        {
            container.Column(column =>
            {
                column.Spacing(10);

                column.Item().Text("Detalle de Credito")
                    .Bold()
                    .FontSize(14);
                column.Item().Table(table => {
                    table.ColumnsDefinition(column1 => {
                        column1.RelativeColumn();
                        column1.ConstantColumn(120);
                    });
                    table.Cell().AlignRight().Text("Total a pagar").Bold();
                    table.Cell().Text($"{model.Credito.SimboloMoneda} {model.Credito.TotalPago:N0}").Bold();

                    table.Cell().AlignRight().Text("Fecha de pago").Bold();
                    table.Cell().Text($"{model.Credito.FechaPago:dd/MM/yyyy}").Bold();
                });

            });
        }
    }
}