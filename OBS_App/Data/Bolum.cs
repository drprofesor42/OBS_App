namespace OBS_App.Data
{
    public class Bolum
    {
        public int Id { get; set; }
        public string BolumAd { get; set; }
        public string BolumBaskani { get; set; }
        public int FakulteId { get; set; }
        public ICollection<Ders> Dersler { get; set; } = new List<Ders>();
        public ICollection<OgrenciNumara> OgrenciNumara { get; set; } = new List<OgrenciNumara>();
        public ICollection<Ogretmens> Ogretmens { get; set; } = new List<Ogretmens>();
        public ICollection<OkulDonemDers> OkulDonemDers { get; set; } = new List<OkulDonemDers>();
    }
}
