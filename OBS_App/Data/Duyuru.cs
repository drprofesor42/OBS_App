namespace OBS_App.Data
{
    public class Duyuru
    {
        public int duyuruId { get; set; }
        public int duyuruGonderici { get; set; }
        public Profesor Profesor { get; set; } = null!;
        public string duyuruMesaj { get; set; }
        public DateTime olusturmaTarihi { get; set; }
    }
}
