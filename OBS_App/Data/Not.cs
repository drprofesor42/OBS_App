namespace OBS_App.Data
{
    public class Not
    {
        public int Id { get; set; }
        public int? NotOdev { get; set; }
        public int? NotVize { get; set; }
        public int? NotFinal { get; set; }
        public DateOnly? NotTarihi { get; set; }
        public int? DersId { get; set; }
        public Ders? Ders { get; set; }
        public int OgrencisId { get; set; }
        public Ogrencis? Ogrencis { get; set; }
        public int? OgretmensId { get; set; }
        public Ogretmens? Ogretmens { get; set; }

    }
}
