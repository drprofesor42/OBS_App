namespace OBS_App.Data
{
    public class Ders
    {
        public int dersId { get; set; }
        public int dersProfId { get; set; }
        public Profesor Profesor { get; set; } = null!;
        public string dersIsim { get; set; }
        public string dersKod { get; set; }
        public int dersKredi { get; set; }
        public int dersAkts { get; set; }
        public DateTime olusturmaTarihi { get; set; }
    }
}
