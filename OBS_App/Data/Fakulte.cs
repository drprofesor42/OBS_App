namespace OBS_App.Data
{
    public class Fakulte
    {
        public int Id { get; set; }
        public string FakulteAd { get; set; }
        public DateOnly OlusturmaTarihi { get; set; }
        public ICollection<Bolum> Bolumler { get; set; } = new List<Bolum>();
        public ICollection<Ogretmens> Ogretmens { get; set; } = new List<Ogretmens>();
        public ICollection<Ogrencis> Ogrencis { get; set; }= new List<Ogrencis>();
    }
}
