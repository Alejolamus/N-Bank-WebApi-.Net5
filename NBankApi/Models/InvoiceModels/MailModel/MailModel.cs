using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Models.InvoiceModels.MailModel
{
    public class MailModel
    {
        public string email { get; set; }
        public MemoryStream pdf { get; set; }
        public MailModel(string Email, MemoryStream Pdf)
        {
            email = Email;
            pdf = Pdf;
        }
    }
}
