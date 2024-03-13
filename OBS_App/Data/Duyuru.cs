namespace OBS_App.Data
{
    public class Duyuru
    {
        public int Id { get; set; }
        public int OgretmenId { get; set; }
        public string DuyuruBaslik { get; set; }
        public string DuyuruMesaj { get; set; }
        public DateOnly OlusturmaTarihi { get; set; }
        public int? OgretmensId { get; set; }
        public Ogretmens? Ogretmens { get; set; }
    }
}
