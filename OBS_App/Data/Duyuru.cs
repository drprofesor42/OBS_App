namespace OBS_App.Data
{
    public class Duyuru
    {
        public int Id { get; set; }
        public int duyuruGonderici { get; set; }
		public string duyuruBaslık { get; set; }
        public string duyuruMesaj { get; set; }
        public DateOnly olusturmaTarihi { get; set; }
        /*public Ogretmens Profesor { get; set; } = null!;*/
    }
}
