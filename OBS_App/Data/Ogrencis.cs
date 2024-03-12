using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace OBS_App.Data
{
    public class Ogrencis
    {
        public int Id { get; set; }
        public int ogrenciTc { get; set; }
        public int ogrenciNo { get; set; }
        public string ogrenciAd { get; set; } = null!;
        public string ogrenciSoyad { get; set; } = null!;
        public DateOnly DogumTarihi { get; set; }
        public string? Eposta { get; set; } 
        public string ogrenciCinsiyet { get; set; } 
        public int ogrenciSinif { get; set; } 
        public int ogrenciBolum { get; set; }
        public int TelefonNo { get; set; }
        public string ogrenciParola { get; set; } = null!;
        public int ogrenciDanisman { get; set; }
        public DateOnly kayitTarihi { get; set; }

        /*public int BolumId { get; set; }*/

        /*public Bolum Bolum  { get; set; }*/
    }
}
