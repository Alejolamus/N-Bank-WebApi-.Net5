using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NBankApi.Models.myEnums;

namespace NBankApi.Models.DataBase
{
    public class Partners
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string partners_code { get; set; }
        [Required]
        public PartnersTypes.tipos_de_aliados partner_type { get; set; }
        [Required]
        public int nit { get; set; }
        [Required]
        public string location { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public Boolean is_active { get; set; }
        [Required]
        public decimal collection_commission { get; set; }
        [Required]
        public DateTime create_at { get; set; }
        [Required]
        public string hashApiPass { get; set; }
        public virtual Partners aliado { get; set; }
        public virtual ICollection<Collects> recaudos { get; set; }
    }
}
