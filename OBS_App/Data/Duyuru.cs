namespace OBS_App.Data
{
    public class Duyuru
    {
        public int duyuruId { get; set; }
        public int duyuruGondericiAdmin { get; set; }
        public int duyuruGondericiProf { get; set; }
		public string duyuruBaslık { get; set; }
        public string duyuruMesaj { get; set; }
        public DateOnly olusturmaTarihi { get; set; }
        /*public Ogretmens Profesor { get; set; } = null!;*/
    }
}
