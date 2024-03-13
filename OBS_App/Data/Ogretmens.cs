using Microsoft.EntityFrameworkCore;

namespace OBS_App.Data
{
    public class Ogretmens
    {
        public int Id { get; set; }
        public string OgretmenAd { get; set; }
        public string OgretmenSoyad { get; set; }
        public string OgretmenUnvan { get; set; }
        public string OgretmenEposta { get; set; }
        public string OgretmenOfis { get; set; }
        public string OgretmenGorusme { get; set; }
        public string OgretmenTelefon { get; set; }
        public string OgretmenCinsiyet { get; set; }
        public DateOnly OgretmenDogumTarihi { get; set; }
        public DateOnly OgretmenBaslamaTarihi { get; set; }
        public int? BolumId { get; set; }
        public ICollection<OgretmenOgrenci> OgretmenOgrenciler { get; set; } = new List<OgretmenOgrenci>();
        public ICollection<Ders> Dersler { get; set; } = new List<Ders>();
        public ICollection<Duyuru> Duyurular { get; set; } = new List<Duyuru>();


    }
}
