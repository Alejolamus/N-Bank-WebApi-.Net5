using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using NBankApi.Models.myEnums;
using System.Collections.Generic;

namespace NBankApi.Models.DataBase
{
    public class Credits
    {
        [Key]
        public int id { get; set; }
        [Required]
        [ForeignKey("id_user")]
        public int user_id { get; set; }
        [Required]
        public DateTime star_date { get; set; }
        [Required]
        public Frecuencia.frecuencia payment_frequency { get; set; }
        [Required]
        public int installment_count { get; set; }
        [Required]
        public DateTime next_cutoff_date { get; set; }
        [Required]
        public EstadoDeAprovacion.estado state { get; set; }
        [Required]
        public decimal value { get; set; }
        [Required]
        public decimal outstanding_balance { get; set; }
        [Required]
        public decimal overdue_balance { get; set; }
        [Required]
        public DateTime past_due_date { get; set; }
        [Required]
        [ForeignKey("id_ currency")]
        public int id_currency { get; set; }
        public bool acceptConditions { get; set; }
        public decimal insurancePremium { get; set; }
        public decimal installamentAmount { get; set; }
        [Required]
        public int PaidInstallament { get; set; }
        public virtual ICollection<Collects> recaudos { get; set; }
        public virtual FinancialProfiles perfil { get; set; }
        public virtual ICollection<Invoice> facturas { get; set; }

    }
}
