namespace OBS_App.Data
{
    public class OgretmenOgrenci
    {
        public int Id { get; set; }
        public int OgrencisId { get; set; }
        public Ogrencis Ogrencis { get; set; }
        public int OgretmensId { get; set; }
        public Ogretmens Ogretmens { get; set; }
        
    }
}
