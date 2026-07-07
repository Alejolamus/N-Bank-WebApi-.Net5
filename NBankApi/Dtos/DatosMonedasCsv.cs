using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBankApi.Dtos
{
    public class DatosMonedasCsv
    {

        [Name("ISO Alpha-2")]
        public string isoAlpha2 { get; set; }

        [Name("ISO Alpha-3")]
        public string isoAplaha3 { get; set; }
        [Name("Country")]
        public string country { get; set; }
        [Name("Currency Code")]
        public string currencyCode { get; set; }
        [Name("Currency Name")]
        public string currencyName { get; set; }
        [Name("Symbol")]
        public string Symbol { get; set; }
    }
}
