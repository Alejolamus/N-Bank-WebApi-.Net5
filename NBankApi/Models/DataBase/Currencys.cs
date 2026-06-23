using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NBankApi.Models.DataBase
{
    public class Currencys
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(2)]
        public string iso_alpha_2 { get; set; }
        [Required]
        [StringLength(3)]
        public string iso_alpha_3 { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string currency_code { get; set; }
        [Required]
        public string currency_name { get; set; }
        [Required]
        public string symbol { get; set; }
        public virtual ICollection<Collects> recaudos { get; set; }
        public virtual ICollection<Credits> creditos { get; set; }
        public virtual ICollection<FinancialProfiles> perfiles { get; set; }


    }
}
