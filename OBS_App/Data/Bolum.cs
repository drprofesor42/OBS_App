namespace OBS_App.Data
{
    public class Bolum
    {
        public int bolumId { get; set; }
        public FakulteBolum FakulteBolum { get; set; } = null!;
        public int bolumProfId { get; set; }
        public string bolumIsim { get; set; }
        public DateTime olusturmaTarihi { get; set; }
    }
}
