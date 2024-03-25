namespace OBS_App.Data
{
    public class Bİldirim
    {
        public int Id { get; set; }
        public string? BildirimBaslik { get; set; }
        public string? BildirimDuyuru { get; set; }
        public bool BildirimOkunma { get; set; } = false;
        public string? BildirimOkunmaEposta { get; set; }
        public int OgrencisId { get; set; }
        public int OgretmensId { get; set; }
    }
}
