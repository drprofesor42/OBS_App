using Microsoft.EntityFrameworkCore;
using OBS_App.Models;
using System.ComponentModel.DataAnnotations;

namespace OBS_App.Data
{
    public class Ogrencis
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
		[RegularExpression("^[0-9]*$", ErrorMessage = "Sadece rakam girebilirsiniz.")]
		[StringLength(11, ErrorMessage = "11 karakter uzunluğunda olmalıdır.", MinimumLength = 11)]
        public string OgrenciTc { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string OgrenciAd { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string OgrenciSoyad { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string OgrenciEposta { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string OgrenciCinsiyet { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public int OgrenciSinif { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
		[RegularExpression("^[0-9]*$", ErrorMessage = "Sadece rakam girebilirsiniz.")]
		[StringLength(11, ErrorMessage = "11 karakter uzunluğunda olmalıdır.", MinimumLength = 11)]
        public string OgrenciTelefon { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        [MinLength(8, ErrorMessage = "Şifreniz en az 7 karakter olmalıdır")]
        public string OgrenciParola { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
		[Compare("OgrenciParola", ErrorMessage = "Şifreler eşleşmiyor.")]
		[MinLength(8, ErrorMessage = "Şifreniz en az 7 karakter olmalıdır")]
        public string OgrenciParolaOnayla { get; set; }
        public string? OgrenciDanisman { get; set; }

        public DateOnly OgrenciKayitTarihi { get; set; }

        public DateOnly OgrenciDogumTarihi { get; set; }

        public int AdresId { get; set; }
        public Adres Adres { get; set; }
        public int? BolumId { get; set; }
        public Bolum? Bolum { get; set; }
        public ICollection<DersOgrenci> DersOgrenciler { get; set; } = new List<DersOgrenci>();
        public ICollection<OgretmenOgrenci> OgretmenOgrenciler { get; set; } = new List<OgretmenOgrenci>();

    }

}
