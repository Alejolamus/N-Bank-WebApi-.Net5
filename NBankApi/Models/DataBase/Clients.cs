using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NBankApi.Models.myEnums;

namespace NBankApi.Models.DataBase
{
    public class Clients
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [ForeignKey("id_location")]
        public int id_location { get; set; }
        [Required]
        public typedocument.typedocu document_type { get; set; }
        [Required]
        public int document { get; set; }
        [Required]
        public string password_hash { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        [StringLength(13)]
        public string cellphone { get; set; }
        public string phone { get; set; }
        public virtual ICollection<Credits> creditos { get; set; }
        public virtual ICollection<FinancialProfiles> perfiles { get; set; }
    }
}
