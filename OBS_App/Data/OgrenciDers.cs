namespace OBS_App.Data
{
    public class OgrenciDers
    {
        public int ogrenciDersId { get; set; }
        public int ogrenciId { get; set; }
        public int dersId { get; set; }
        public Ders Ders { get; set; } = null!;
        public int dersSinavSonuc1 { get; set; }
        public int dersSinavSonuc2 { get; set; }
        public int dersFinalSonuc { get; set; }
        public DateTime olusturmaTarihi { get; set; }
    }
}
