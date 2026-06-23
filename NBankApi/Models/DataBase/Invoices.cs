using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBankApi.Models.DataBase
{
    public class Invoices
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string invoice_number { get; set; }
        [Required]
        [ForeignKey("id_credit")]
        public int id_credit { get; set; }
        [Required]
        public decimal current_balance { get; set; }
        [Required]
        public DateTime on_time_payment { get; set; }
        public virtual ICollection<Collects> recaudos { get; set; }
        public virtual FinancialStatus estadoDeRecudo { get; set; }
    }
}