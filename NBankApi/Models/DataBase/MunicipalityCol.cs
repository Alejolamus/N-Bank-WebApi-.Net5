using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NBankApi.Models.DataBase
{
    public class MunicipalityCol
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string department { get; set; }
        [Required]
        public string municipality { get; set; }
        public virtual ICollection<Clients> clientes { get; set; }

    }
}