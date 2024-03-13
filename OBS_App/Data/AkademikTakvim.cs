namespace OBS_App.Data
{
    public class AkademikTakvim
    {
        public int Id { get; set; }
        public DateOnly AkademikTakvimBaslangic { get; set; }
        public DateOnly AkademikTakvimBitis { get; set; }
        public string AkademikTakvimAktivite { get; set; }
    }
}
