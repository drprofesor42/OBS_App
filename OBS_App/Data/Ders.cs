namespace OBS_App.Data
{
    public class Ders
    {
        public int Id { get; set; }
        public string DersAd { get; set; }
        public string DersKod { get; set; }
        public int DersKredi { get; set; }
        public int DersAkts { get; set; }
        public DateOnly OlusturmaTarihi { get; set; }
    }
}
