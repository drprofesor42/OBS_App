namespace OBS_App.Data
{
    public class DersOgrenci
    {
        public int Id { get; set; }
        public int OgrencisId { get; set; }
        public Ogrencis Ogrencis { get; set; }
        public int DersId { get; set; }
        public Ders Ders { get; set; }
    }
}
