namespace OBS_App.Data
{
    public class AkademikTakvim
    {
        public int akademikTakvimId { get; set; }
        public DateTime akademikTakvimBaslangic { get; set; }
        public DateTime akademikTakvimBitis { get; set; }
        public string? akademikTakvimAktivite { get; set; }
        public DateTime olusturmaTarihi { get; set; }
    }
}
