using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Dtos
{
    public class ValoresCoutaSeguroCredt
    {
        public decimal seguro { get; set; }
        public decimal cuota { get; set; }
        public ValoresCoutaSeguroCredt(decimal vSeguro, decimal vCuota)
        {
            seguro = vSeguro;
            cuota = vCuota;
        }
    }
}