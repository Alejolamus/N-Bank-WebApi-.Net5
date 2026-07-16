using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Dtos.creditoDataApp
{
    public class CotizarData
    {
        public DtosProfiles perfil { get; set; }
        public DtosSolicitudCredito dataCredit { get; set; }
    }
}
