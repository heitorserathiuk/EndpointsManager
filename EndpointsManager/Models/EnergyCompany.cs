using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EndpointsManager.Models
{
    public class EnergyCompany
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int energyCompanyId { get; set; }

        public string name { get; set; }

        public ICollection<Endpoint> endpoints { get; set; }
    }
}
