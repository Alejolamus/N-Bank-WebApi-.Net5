using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBankApi.Models.DataBase
{
    public class FinancialStatus
    {
        [Key]
        public int id { get; set; }
        [Required]
        [ForeignKey("idInvoice")]
        public int idInvoice { get; set; }
        [Required]
        public decimal seguro { get; set; }
        [Required]
        public decimal cuota { get; set; }
        [Required]
        public decimal mora { get; set; }
    }
}