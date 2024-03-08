namespace OBS_App.Data
{
    public class AkademikTakvims
    {
        public int akademikTakvimsId { get; set; }
        public DateOnly akademikTakvimBaslangic { get; set; }
        public DateOnly akademikTakvimBitis { get; set; }
        public string? akademikTakvimAktivite { get; set; }
    }
}
