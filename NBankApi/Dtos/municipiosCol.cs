using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Dtos
{
    public class municipiosCol
    {
        [Name("Codigo Departamento")]
        public string CodigoDepartamento { get; set; }
        [Name("Nombre Departamento")]
        public string Departamento { get; set; }
        [Name("Codigo Municipio")]
        public string CodigoMunicipio { get; set; }
        [Name("Nombre Municipio")]
        public string Municipio { get; set; }
    }
}
