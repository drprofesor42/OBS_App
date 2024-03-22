using System.ComponentModel.DataAnnotations;

namespace OBS_App.Data
{
    public class Ders
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public string DersAd { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
		public string DersKod { get; set; }

		[Required(ErrorMessage = "*Zorunlu Alan")]
		[RegularExpression("^[0-9]*$", ErrorMessage = "Sadece rakam girebilirsiniz.")]
		public string DersKredi { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
		[RegularExpression("^[0-9]*$", ErrorMessage = "Sadece rakam girebilirsiniz.")]
		public string DersAkts { get; set; }
        public DateOnly OlusturmaTarihi { get; set; }
        [Required(ErrorMessage = "*Zorunlu Alan")]
        public int? BolumId { get; set; }
        public Bolum? Bolum { get; set; }
        public int? OgretmensId { get; set; }
        public Ogretmens? Ogretmens { get; set; }
        public int? FakulteId { get; internal set; }
        public Fakulte? Fakulte { get; set; }
        public ICollection<Not> notlar { get; set; } = new List<Not>();
        public ICollection<Ogrencis> Ogrencisler { get; set; } = new List<Ogrencis>();
       
    }
}
