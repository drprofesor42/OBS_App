namespace OBS_App.Data
{
    public class Ogrenci
    {
        public int ogrenciId { get; set; }
        public OgrenciMesaj OgrenciMesaj { get; set; } = null!;
        public OgrenciDers OgrenciDers { get; set; } = null!;
        public int ogrenciDanisman { get; set; }
        public Ogretmens Profesor { get; set; } = null!;
        public int ogrenciTc { get; set; }
        public int ogrenciNo { get; set; }
        public DateTime ogrenciDogumTarihi { get; set; }
        public bool ogrenciCinsiyet { get; set; }
        public string ogrenciIsim { get; set; } = null!;
        public string ogrenciSoyad { get; set; } = null!;
        public string ogrenciParola { get; set; } = null!;
        public string ogrenciEposta { get; set; } = null!;
        public int ogrenciBolum { get; set; }
        public Bolum Bolum { get; set; } = null!;
        public DateTime ogrenciOlusturmaTarihi { get; set; }
    }
}
