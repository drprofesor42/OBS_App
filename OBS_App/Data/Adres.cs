using System.ComponentModel.DataAnnotations;

namespace OBS_App.Data
{
    public class Adres
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string Ulke { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string Ilce { get; set; }
        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string AcıkAdres { get; set; }
    }
}
