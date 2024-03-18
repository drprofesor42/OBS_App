namespace OBS_App.Data
{
    public class Fakulte
    {
        public int Id { get; set; }
        /*public FakulteBolum FakulteBolum { get; set; } = null!;*/
        public int fakulteProfId { get; set; }
        /*public Ogretmens Profesor { get; set; } = null!;*/
        public string fakulteIsim { get; set; }
        public DateTime olusturmaTarihi { get; set; }
    }
}
