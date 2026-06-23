using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using NBankApi.Models.myEnums;

namespace NBankApi.Models.DataBase
{
    public class Collects
    {

        [Key]
        public int id { get; set; }
        [Required]
        [ForeignKey("idInvoice")]
        public int idInvoice { get; set; }
        [Required]
        public decimal collection { get; set; }
        [Required]
        public DateTime paymentDate { get; set; }
        [Required]
        public TipoDePago.tipo_pago paymentType { get; set; }
        [Required]
        [ForeignKey("id_partner")]
        public int idPartner { get; set; }
        [Required]
        public string AuthorizationCode { get; set; }
    }
}