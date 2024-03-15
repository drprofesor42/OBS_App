namespace OBS_App.Data
{
    public class Sinif
    {
        public int Id { get; set; }
        public string SinifNumarasi { get; set; }
        public int? DonemId { get; set; }
        public Donem? Donem { get; set; }
        public ICollection<Bolum> Bolumler { get; set; } = new List<Bolum>();
        public ICollection<Ogretmens> Ogretmensler { get; set; } = new List<Ogretmens>();
        public ICollection<Ogrencis> Ogrencisler { get; set; } = new List<Ogrencis>();
        public ICollection<Ders> Dersler { get; set; } = new List<Ders>();
    }
}
