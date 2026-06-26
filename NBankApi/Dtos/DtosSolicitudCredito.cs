using NBankApi.Models.myEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Dtos
{
    public class DtosSolicitudCredito
    {
        public decimal valueOfCredit { get; set; }
        public Frecuencia.frecuencia frecuenciaCobro { get; set; }
        public DateTime fechaInicio { get; set; }
        public int numCuotas { get; set; }
        public int idCurrency { get; set; }
    }
}