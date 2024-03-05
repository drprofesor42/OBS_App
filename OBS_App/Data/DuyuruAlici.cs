namespace OBS_App.Data
{
    public class DuyuruAlici
    {
        public int duyuruAliciId { get; set; }
        public int duyuruId { get; set; }
        public Duyuru Duyuru { get; set; } = null!;
        public int duyuruAlici_ogrenci { get; set; }
        public Ogrenci Ogrenci { get; set; } = null!;
        public DateTime duyuruAliciOlusturmaTarihi { get; set; }
    }
}
