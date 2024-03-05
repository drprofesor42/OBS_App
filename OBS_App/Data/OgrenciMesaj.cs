namespace OBS_App.Data
{
    public class OgrenciMesaj
    {
        public int ogrenciMesajId { get; set; }
        public int ogrenciMesajGonderici { get; set; }
        public int ogrenciMesajAlici { get; set; }
        public string ogrenciMesajMesaj { get; set; }
        public DateTime olusturmaTarihi { get; set; }
    }
}
