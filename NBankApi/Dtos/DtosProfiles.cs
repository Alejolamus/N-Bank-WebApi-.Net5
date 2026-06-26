using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Dtos
{
    public class DtosProfiles
    {
        public int idClient { get; set; }
        public decimal minGanadoMensual { get; set; }
        public decimal maxGanadoMensual { get; set; }
        public decimal gastos { get; set; }

    }
}