namespace OBS_App.Data
{
    public class Ders
    {
        public int Id { get; set; }
        public string DersAd { get; set; }
        public string DersKod { get; set; }
        public int DersKredi { get; set; }
        public int DersAkts { get; set; }
        public DateOnly OlusturmaTarihi { get; set; }
        public int? BolumId { get; set; }
        public Bolum? Bolum { get; set; } = null!;
        public int? OgretmensId { get; set; }
        public Ogretmens? Ogretmens { get; set; }
        public ICollection<Not> notlar { get; set; } = new List<Not>();
        public ICollection<Ogrencis> Ogrencisler { get; set; } = new List<Ogrencis>();
        public ICollection<DersOgrenci> DersOgrenciler { get; set; } = new List<DersOgrenci>();
        public ICollection<OkulDonemDers> OkulDonemDersler { get; set; } = new List<OkulDonemDers>();



    }
}
