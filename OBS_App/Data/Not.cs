using System.ComponentModel.DataAnnotations;

namespace OBS_App.Data
{
    public class Not
    {
        public int Id { get; set; }
        public int? NotOdev { get; set; }
        public int? NotVize { get; set; }
        public int? NotFinal { get; set; }
        public DateOnly? NotOdevTarih { get; set; }
        public DateOnly? NotVizeTarih { get; set; }
        public DateOnly? NotFinalTarih { get; set; }
        public string? NotOdevSaat { get; set; }
        public string? NotVizeSaat { get; set; }
        public string? NotFinalSaat { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        public int? DersId { get; set; }
        public Ders? Ders { get; set; }
        public int OgrencisId { get; set; }
        public Ogrencis? Ogrencis { get; set; }
        public int? OgretmensId { get; set; }
        public Ogretmens? Ogretmens { get; set; }
        public Bolum? Bolum { get; set; }
        public int? NotBilgiId { get; set; }
    }
}
