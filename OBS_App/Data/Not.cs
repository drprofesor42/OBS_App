using System.ComponentModel.DataAnnotations;

namespace OBS_App.Data
{
    public class Not
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string NotTip { get; set; }

        public int? NotPuan { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public DateOnly NotTarihi { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string NotSaat { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public int? DersId { get; set; }
        public Ders? Ders { get; set; }
        public int OgrencisId { get; set; }
        public Ogrencis? Ogrencis { get; set; }
        public int? OgretmensId { get; set; }
        public Ogretmens? Ogretmens { get; set; }
        public Bolum? Bolum { get; set; }

    }
}
