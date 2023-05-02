using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ExpressV.Models
{
    public class Interventions
    {
        [Key]
        public int InterventionId { get; set; }
        [ForeignKey(nameof(Interventions))]
        [Required]
        public string CodeVin { get; set; }
        public ICollection<Reparations>? Reparations { get; set; }
    }
}
