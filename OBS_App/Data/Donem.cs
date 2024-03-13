namespace OBS_App.Data
{
    public class Donem
    {
        public int Id { get; set; }
        public string DonemAd { get; set; }
        public int DonemYariyil { get; set; }
        public ICollection<OkulDonemDers> OkulDonemDersler { get; set; } = new List<OkulDonemDers>();
    }
}
