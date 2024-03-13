namespace OBS_App.Data
{
    public class Ders
    {
        public int Id { get; set; }
        public string DersAd { get; set; }
        public string DersKod { get; set; }
        public int DersKredi { get; set; }
        public int DersAkts { get; set; }
        public Bolum Bolum { get; set; }
        /*public int BolumId { get; set; }*/
        public int OgretmensId { get; set; }
        /*public ICollection<Not> Notlar { get; set; } = new List<Not>();
        public ICollection<DersOgrenci> DersOgrenciler { get; set; } = new List<DersOgrenci>();
        public ICollection<OkulDonemDers> OkulDonemDersler { get; set; } = new List<OkulDonemDers>();*/

    }
}
