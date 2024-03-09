namespace OBS_App.Data
{
    public class Ogrencis
    {
        public int Id { get; set; }
        public string OgrenciTc { get; set; }
        public string OgrenciNumara { get; set; }
        public string OgrenciAd { get; set; }
        public string OgrenciSoyad { get; set; }
        public string OgrenciEposta { get; set; }
        public string OgrenciCinsiyet { get; set; }
        public int OgrenciSinif { get; set; }
        public string OgrenciTelefon { get; set; }
        public string OgrenciParola { get; set; }
        public string OgrenciParolaOnayla { get; set; }
        public int OgrenciDanisman { get; set; }
        public DateOnly OgrenciKayitTarihi { get; set; }
        public DateOnly OgrenciDogumTarihi { get; set; }
        public string OgrenciBolum { get; set; }
    }
}
