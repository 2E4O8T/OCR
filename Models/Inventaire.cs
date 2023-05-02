using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExpressV.Models
{
    public class Inventaire
    {
        [Key]
        public int CodeVin { get; set; }
        [Required]
        [Range(1990, int.MaxValue)]
        [DisplayName("Année")]
        public int Annee { get; set; }
        [Required]
        [DisplayName("Marque")]
        public string Marque { get; set; }
        [Required]
        [DisplayName("Modèle")]
        public string Modele { get; set; }
        [Required]
        [DisplayName("Finition")]
        public string Finition { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date d'achat")]
        public DateTime DateAchat { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [DisplayName("Prix d'achat")]
        public float PrixAchat { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Prix de vente")]
        public float PrixVente { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date de vente")]
        public DateTime DateVente { get; set; }
        [DisplayName("Véhicule disponible")]
        public bool IsVente { get; set; }
        public virtual Photo? Photo { get; set; }
        public Reparations? Reparations { get; set; }
    }
}
