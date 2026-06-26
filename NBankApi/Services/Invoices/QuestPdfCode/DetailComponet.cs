using NBankApi.Models.InvoiceModels;
using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Services.Invoices.QuestPdfCode
{
    public class DetailComponet
    {
        public static void detailComponent(QuestPDF.Infrastructure.IContainer container,
            CreditInvoiceModel model)
        {
            container.Column(column =>
            {
                column.Spacing(10);

                column.Item().Text("Detalle de Credito")
                    .Bold()
                    .FontSize(14);

                column.Item().Table(table1 =>
                {
                    table1.ColumnsDefinition(columns1 => {
                        columns1.RelativeColumn();
                        columns1.ConstantColumn(120);
                    });
                    table1.Header(header1 => {
                        header1.Cell().Text("Concepto");
                        header1.Cell().Text("Estado");
                    });
                    table1.Cell().Text("Valor del credito");
                    table1.Cell().Text($"{model.Credito.SimboloMoneda} {model.Credito.ValorCredito:N0}");

                    table1.Cell().Text("Cuota numero");
                    table1.Cell().Text($"{model.Credito.CuotaActVsTotalCuotas}");

                    table1.Cell().Text("Deuda actual");
                    table1.Cell().Text($"{model.Credito.SimboloMoneda} {model.Credito.SaldoPendiente:N0}");
                }
                    );

                column.Spacing(10);

                column.Item().Text("Detalle de Cobro")
                    .Bold()
                    .FontSize(14);

                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.ConstantColumn(120);
                    });
                    table.Header(header =>
                    {
                        header.Cell().Text("Concepto");
                        header.Cell().Text("Valor");
                    });

                    table.Cell().Text("Seguro");
                    table.Cell().Text($"{model.Credito.SimboloMoneda} {model.DetallePago.Seguro:N0}");

                    table.Cell().Text("Intereses");
                    table.Cell().Text($"{model.Credito.SimboloMoneda} {model.DetallePago.Interes:N0}");

                    table.Cell().Text("Abono Capital");
                    table.Cell().Text($"{model.Credito.SimboloMoneda} {model.DetallePago.Capital:N0}");
                    if (model.Credito.SaldoMora < 0)
                    {
                        table.Cell().Text("Saldo mora");
                        table.Cell().Text($"{model.Credito.SimboloMoneda} {model.Credito.SaldoMora:N0}");

                        table.Cell().Text("Interes de mora");
                        table.Cell().Text($"{model.Credito.SimboloMoneda} {model.DetallePago.InteresMora:N0}");
                    }
                });
            });
        }
    }
}