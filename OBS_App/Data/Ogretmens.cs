
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using OBS_App.Models;

namespace OBS_App.Data
{
    public class Ogretmens
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string OgretmenAd { get; set; }
        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string OgretmenSoyad { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string OgretmenUnvan { get; set; }
        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string OgretmenEposta { get; set; }
        [Required(ErrorMessage = "*Zorunlu Alan")]
        [MinLength(8, ErrorMessage = "Şifreniz en az 7 karakter olmalıdır")]
        public string OgretmenParola { get; set; }
        [Required(ErrorMessage = "*Zorunlu Alan")]
		[Compare("OgretmenParola", ErrorMessage = "Şifreler eşleşmiyor.")]
		[MinLength(8, ErrorMessage = "Şifreniz en az 7 karakter olmalıdır")]
        public string OgretmenParolaOnayla { get; set; }
        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string OgretmenOfis { get; set; }
        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string OgretmenGorusme { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
		[RegularExpression("^[0-9]*$", ErrorMessage = "Sadece rakam girebilirsiniz.")]
		[StringLength(11, ErrorMessage = "11 karakter uzunluğunda olmalıdır.", MinimumLength = 11)]
        public string OgretmenTelefon { get; set; }
        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string OgretmenCinsiyet { get; set; }
        public DateOnly OgretmenDogumTarihi { get; set; }
        public DateOnly OgretmenBaslamaTarihi { get; set; }
        public int AdresId { get; set; }
        public Adres Adres { get; set; }
        public int? BolumId { get; set; }
        public Bolum? Bolum { get; set; }
        public int? FakulteId { get; set; }
        public  Fakulte? Fakulte { get; set; }
        public ICollection<Ders> Dersler { get; set; } = new List<Ders>();
        public ICollection<Duyuru> Duyurular { get; set; } = new List<Duyuru>();
        public ICollection<Ogrencis> Ogrencisler { get; set; } = new List<Ogrencis>();
        public ICollection<Not> Notlar { get; set; } = new List<Not>();

    }
}
