using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Models.InvoiceModels
{
    public class InvoiceClientInfo
    {
        public string Nombre { get; set; }

        public string Documento { get; set; }

        public string Correo { get; set; }
        public InvoiceClientInfo(string name,
                                 string document,
                                 string email)
        {
            Nombre = name;
            Documento = document;
            Correo = email;
        }
    }
}
