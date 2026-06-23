using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NBankApi.Models.myEnums;

namespace NBankApi.Models.DataBase
{
    public class FinancialProfiles
    {
        [Key]
        public int id { get; set; }
        [Required]
        public NivelEconomico.rangos income_range_label { get; set; }
        [Required]
        public decimal min_income { get; set; }
        [Required]
        public decimal max_income { get; set; }
        [Required]
        public decimal expense { get; set; }
        [Required]
        [ForeignKey("id_client")]
        public int id_client { get; set; }
        [Required]
        [ForeignKey("id_credit")]
        public int id_credit { get; set; }
        [Required]
        [ForeignKey("id_money")]
        public int id_money { get; set; }
    }
}
