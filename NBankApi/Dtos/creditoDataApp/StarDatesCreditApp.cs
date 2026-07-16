using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Dtos.creditoDataApp
{
    public class StarDatesCreditApp
    {
        public DateTime fechaInicio { get; set; }
        public DateTime fechaPrimerPago { get; set; }
        public decimal valorCuota { get; set; }
        public bool valueRiesgo { get; set; }
    }
}
