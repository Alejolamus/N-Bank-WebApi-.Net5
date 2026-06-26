using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBankApi.Models.InvoiceModels;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace NBankApi.Services.Invoices.QuestPdfCode
{
    public class InvoiceDocument : IDocument
    {
        public CreditInvoiceModel Model { get; }

        public InvoiceDocument(CreditInvoiceModel model)
        {
            Model = model;
        }
        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public DocumentSettings GetSettings() => DocumentSettings.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(40);
                page.Header()
            .Element(headercontainer =>
            {
                HeaderCoponent.headerCoponent(headercontainer, Model);
            });

                page.Content()
                    .Column(column =>
                    {
                        column.Spacing(20);

                        column.Item().Element(detailContainer =>
                        {
                            DetailComponet.detailComponent(detailContainer, Model);
                        });

                        column.Item().Element(summaryContainer =>
                        {
                            PaymentSummaryComponent.paymentSummaryComponent(summaryContainer, Model);
                        });
                    });
            });
        }
    }
}