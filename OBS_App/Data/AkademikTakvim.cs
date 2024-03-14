using System.ComponentModel.DataAnnotations;

namespace OBS_App.Data
{
    public class AkademikTakvim
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public DateOnly AkademikTakvimBaslangic { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public DateOnly AkademikTakvimBitis { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string AkademikTakvimAktivite { get; set; }
    }
}
