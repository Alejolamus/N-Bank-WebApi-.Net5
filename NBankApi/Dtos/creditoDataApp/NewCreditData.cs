using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Dtos.creditoDataApp
{
    public class NewCreditData
    {
        public int idCliente { get; set; }
        public int enumFrecuenciaFront { get; set; }
        public int numDeCuotras { get; set; }
        public DateTime primerPago { get; set; }
        public decimal valorCredito { get; set; }
        public int moneda { get; set; } 
    }
}
