using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Dtos.Dataform
{
    public class currencyDataForm
    {
        public int idMoneda { get; set; }
        public string pais { get; set; }
        public string nombre { get; set; }
        public string symbolo { get; set; }
    }
}
