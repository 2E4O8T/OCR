using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ExpressV.Models
{
    public class Reparations
    {
        [Key]
        public int ReparationId { get; set; }
        [ForeignKey(nameof(Reparations))]
        public int InventaireId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date de disponibilité")]
        public DateTime DateDisponibilite { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [DisplayName("Coût des réparations")]
        public float CoutReparation { get; set; }
        public Inventaire? Inventaire { get; set; }
    }
}
