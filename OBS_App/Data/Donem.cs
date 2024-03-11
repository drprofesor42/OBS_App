namespace OBS_App.Data
{
    public class Donem
    {
        public int Id { get; set; }
        public string DonemAd { get; set; }
        public int DonemYariyil { get; set; }
        public ICollection<OkulDonemDers> OkulDonemDers { get; set; } = new List<OkulDonemDers>();
    }
}
