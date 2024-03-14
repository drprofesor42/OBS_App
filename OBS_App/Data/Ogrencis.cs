using Microsoft.EntityFrameworkCore;
using OBS_App.Models;

namespace OBS_App.Data
{
    public class Ogrencis
    {
        public int Id { get; set; }
        public string OgrenciTc { get; set; }
        public string OgrenciAd { get; set; }
        public string OgrenciSoyad { get; set; }
        public string OgrenciEposta { get; set; }
        public string OgrenciCinsiyet { get; set; }
        public int OgrenciSinif { get; set; }
        public string OgrenciTelefon { get; set; }
        public string OgrenciParola { get; set; }
        public string OgrenciParolaOnayla { get; set; }
        public string? OgrenciDanisman { get; set; }
        public DateOnly OgrenciKayitTarihi { get; set; }
        public DateOnly OgrenciDogumTarihi { get; set; }
        public int AdresId { get; set; }
        public Adres Adres { get; set; }
        public int? BolumId { get; set; }
        public Bolum? Bolum { get; set; }
        public int? FakulteId { get; set; }
        public Fakulte? Fakulte { get; set; }
        public ICollection<Not> Notlar { get; set; } = new List<Not>();

    }

}
