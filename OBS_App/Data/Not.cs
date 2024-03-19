namespace OBS_App.Data
{
    public class Not
    {
        public int Id { get; set; }
        public string? NotTip { get; set; }
        public int? NotPuan { get; set; }
        public DateOnly? NotTarihi { get; set; }
        public string? NotSaat { get; set; }
        public int? DersId { get; set; }
        public Ders? Ders { get; set; }
        public int OgrencisId { get; set; }
        public Ogrencis? Ogrencis { get; set; }
        public int? OgretmensId { get; set; }
        public Ogretmens? Ogretmens { get; set; }
        public Bolum? Bolum { get; set; }

    }
}
