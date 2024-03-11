using OBS_App.Data;

namespace OBS_App.ViewsModel
{
    public class SayılarViewsModel
    {
        public IEnumerable<Fakulte> Fakultes  { get; set; }
        public IEnumerable<Bolum> Bolums { get; set; }
        public IEnumerable<Ders> Derss { get; set; }
        public IEnumerable<Ogrencis> Ogrenciss { get; set; }
        public IEnumerable<Ogretmens> Ogretmenss { get; set; }

    }
}
