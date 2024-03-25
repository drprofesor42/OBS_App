namespace OBS_App.Data
{
    public class Bildirim
    {
        public int Id { get; set; }
        public string? BildirimBaslik { get; set; }
        public string? BildirimDuyuru { get; set; }
        public bool BildirimOkunma { get; set; } = false;
        public string? BildirimEposta { get; set; }
    }
}
