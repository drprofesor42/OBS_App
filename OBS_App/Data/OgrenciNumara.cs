namespace OBS_App.Data
{
    public class OgrenciNumara
    {
        public int Id { get; set; }
        public string OgrenciNumarasi { get; set; }
        public int NotId { get; set; }
        public Not Not { get; set; }
        public int FakulteId { get; set; }
        public Fakulte Fakulte { get; set; }
        public int BolumId { get; set; }
        public Bolum Bolum { get; set; }
    }
}
