namespace OBS_App.Data
{
	public class Bolum
	{
		public int Id { get; set; }
		public string BolumIsmi { get; set; }
		public string BolumBaskani { get; set; }

		public ICollection<Ogretmens> Ogretmenleri { get; set; } = new List<Ogretmens>();

		public ICollection<Ogrencis> Ogrencileri { get; set; } = new List<Ogrencis>();
		//public int bolumProfId { get; set; }
		//public FakulteBolum FakulteBolum { get; set; } = null!;
	}
}
