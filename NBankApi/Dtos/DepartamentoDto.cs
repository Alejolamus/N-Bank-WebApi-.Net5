using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Dtos
{
    public class DepartamentoDto
    {
        public string name { get; set; }
        public List<string> municipios { get; set; }
    }
}
