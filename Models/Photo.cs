using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ExpressV.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        [NotMapped]
        [Display(Name = "Photo")]
        public IFormFile File { get; set; }
        public int FruitId { get; set; }
        public virtual Inventaire? Inventaire { get; set; }
    }
}
