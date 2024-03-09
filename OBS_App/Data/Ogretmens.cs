namespace OBS_App.Data
{
    public class Ogretmens
    {
        public int Id { get; set; }
        public string OgretmenAd { get; set; }
        public string OgretmenSoyad { get; set; }
        public string OgretmenUnvan { get; set; }
        public string OgretmenEposta { get; set; }
        public string OgretmenParola { get; set; }
        public string OgretmenParolaOnayla { get; set; }
        public string OgretmenOfis { get; set; }
        public string OgretmenGorusme { get; set; }
        public string OgretmenTelefon { get; set; }
        public string OgretmenCinsiyet { get; set; }
        public DateOnly OgretmenDogumTarihi { get; set; }
        public DateOnly OgretmenBaslamaTarihi { get; set; }
    }
}
