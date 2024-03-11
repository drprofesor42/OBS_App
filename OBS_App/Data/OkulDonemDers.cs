namespace OBS_App.Data
{
    public class OkulDonemDers
    {
        public int Id { get; set; }
        public int FakulteId { get; set; }
        public Fakulte Fakulte { get; set; }
        public int BolumId { get; set; }
        public Bolum Bolum { get; set; }
        public int DersId { get; set; }
        public Ders Ders { get; set; }
        public int DonemId { get; set; }
        public Donem Donem { get; set; }


    }
}
