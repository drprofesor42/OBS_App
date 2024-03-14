using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace OBS_App.Data
{
    public class Bolum
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string BolumAd { get; set; }
        public string BolumBaskani { get; set; }
        public int? FakulteId { get; set; }
        public Fakulte? Fakulte { get; set; }
        public ICollection<Ders> Dersler { get; set; } = new List<Ders>();
        public ICollection<Ogretmens> Ogretmensler { get; set; } = new List<Ogretmens>();
        public ICollection<Ogrencis> Ogrencisler { get; set; } = new List<Ogrencis>();

    }
}
