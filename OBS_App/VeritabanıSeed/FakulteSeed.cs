using OBS_App.Data;
using OBS_App.Models;

namespace OBS_App.VeritabanıSeed
{
    public class FakulteSeed
    {
        private static readonly string[] List = { "İşletme Fakultesi", "Mühendislik Fakultesi", "Orman Fakultesi", "Fen-Edebiyat Fakultesi" };
        public static void FakulteSeedTest(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityDataContext>();
            var tarih = DateOnly.FromDateTime(DateTime.Today);

            if (!context.Fakulteler.Any())
            {
                for (int i = 0; i < List.Length; i++)
                {
                    context.Fakulteler.Add(new Fakulte
                    {
                        FakulteAd = List[i],
                        OlusturmaTarihi = tarih,

                    });
                    context.SaveChanges();

                }
            }
            if (!context.Bolumler.Any())
            {
                context.Bolumler.Add(new Bolum
                {
                    BolumAd = "Yönetim Bilişim Sistemleri",
                    BolumBaskani = "Ceyda"
                });
                context.Bolumler.Add(new Bolum
                {
                    BolumAd = "İşletme",
                    BolumBaskani = "Birol"
                });
                context.Bolumler.Add(new Bolum
                {
                    BolumAd = "Bilgisayar Mühendisliği",
                    BolumBaskani = "Ahmet"
                });

                context.Bolumler.Add(new Bolum
                {
                    BolumAd = "Yazılım Mühendisliği",
                    BolumBaskani = "Fatma"
                });

                context.SaveChanges();
            }
            if (!context.Dersler.Any())
            {
                context.Dersler.Add(new Ders
                {
                    DersAd = "Programlama Giriş",
                    DersAkts = "21",
                    DersKod = "YBS201",
                    DersKredi = "7"
                });
                context.Dersler.Add(new Ders
                {
                    DersAd = "Nesne Tabanlı Programlama",
                    DersAkts = "6",
                    DersKod = "BMH301",
                    DersKredi = "8"
                }); context.Dersler.Add(new Ders
                {
                    DersAd = "Veri Yapıları ve Algoritmalar",
                    DersAkts = "6",
                    DersKod = "YBS408",
                    DersKredi = "6"
                });

                context.Dersler.Add(new Ders
                {
                    DersAd = "Nesne Yönelimli Programlama",
                    DersAkts = "6",
                    DersKod = "YMH304",
                    DersKredi = "8"
                });

                context.Dersler.Add(new Ders
                {
                    DersAd = "Web Programlama",
                    DersAkts = "6",
                    DersKod = "YBS205",
                    DersKredi = "4"
                });

                context.Dersler.Add(new Ders
                {
                    DersAd = "Veritabanı Yönetimi",
                    DersAkts = "8",
                    DersKod = "ISL309",
                    DersKredi = "6"
                });
                context.SaveChanges();
            }
            if (!context.Ogrenciler.Any())
            {
                context.Ogrenciler.Add(new Ogrencis
                {
                    OgrenciTc = "12345678919",
                    OgrenciAd = "Ceylin",
                    OgrenciSoyad = "Uzun",
                    OgrenciDogumTarihi = DateOnly.FromDateTime(DateTime.Today),
                    OgrenciCinsiyet = "Kız",
                    OgrenciSinif = 1,
                    OgrenciTelefon = "05345678945",
                    OgrenciKayitTarihi = DateOnly.FromDateTime(DateTime.Today),
                    OgrenciEposta = "ceylinuz@gmail.com",
                    OgrenciParola = "123456",
                    OgrenciParolaOnayla = "123456",
                    Adres = new Adres
                    {
                        AcıkAdres = "Ataşehir Mahallesi Sokak: 2 No: 110 Ankara / Merkez",
                        Sehir = "Ankara",
                        Ilce = "Merkez",
                        Ulke = "Türkiye"
                    }

                });
                context.Ogrenciler.Add(new Ogrencis
                {
                    OgrenciTc = "98765432118",
                    OgrenciAd = "Ali",
                    OgrenciSoyad = "Yılmaz",
                    OgrenciDogumTarihi = DateOnly.FromDateTime(new DateTime(2000, 5, 15)),
                    OgrenciCinsiyet = "Erkek",
                    OgrenciSinif = 2,
                    OgrenciTelefon = "05349876545",
                    OgrenciKayitTarihi = DateOnly.FromDateTime(DateTime.Today),
                    OgrenciEposta = "aliyilmaz@gmail.com",
                    OgrenciParola = "abcdef",
                    OgrenciParolaOnayla = "abcdef",
                    Adres = new Adres
                    {
                        AcıkAdres = "Bahçelievler Mahallesi Sokak: 5 No: 220 İstanbul / Kadıköy",
                        Sehir = "İstanbul",
                        Ilce = "Kadıköy",
                        Ulke = "Türkiye"
                    }
                });

                context.Ogrenciler.Add(new Ogrencis
                {
                    OgrenciTc = "45678912317",
                    OgrenciAd = "Ayşe",
                    OgrenciSoyad = "Kaya",
                    OgrenciDogumTarihi = DateOnly.FromDateTime(new DateTime(1999, 10, 8)),
                    OgrenciCinsiyet = "Kız",
                    OgrenciSinif = 3,
                    OgrenciTelefon = "05458456789",
                    OgrenciKayitTarihi = DateOnly.FromDateTime(DateTime.Today),
                    OgrenciEposta = "aysekaya@gmail.com",
                    OgrenciParola = "qwerty",
                    OgrenciParolaOnayla = "qwerty",
                    Adres = new Adres
                    {
                        AcıkAdres = "Kızılay Mahallesi Sokak: 10 No: 15 Ankara / Çankaya",
                        Sehir = "Ankara",
                        Ilce = "Çankaya",
                        Ulke = "Türkiye"
                    }
                });

                context.Ogrenciler.Add(new Ogrencis
                {
                    OgrenciTc = "78912345625",
                    OgrenciAd = "Mehmet",
                    OgrenciSoyad = "Şahin",
                    OgrenciDogumTarihi = DateOnly.FromDateTime(new DateTime(2001, 3, 20)),
                    OgrenciCinsiyet = "Erkek",
                    OgrenciSinif = 1,
                    OgrenciTelefon = "05468789123",
                    OgrenciKayitTarihi = DateOnly.FromDateTime(DateTime.Today),
                    OgrenciEposta = "mehmetsahin@gmail.com",
                    OgrenciParola = "123abc",
                    OgrenciParolaOnayla = "123abc",
                    Adres = new Adres
                    {
                        AcıkAdres = "Alsancak Mahallesi Sokak: 7 No: 30 İzmir / Konak",
                        Sehir = "İzmir",
                        Ilce = "Konak",
                        Ulke = "Türkiye"
                    }
                });
                context.SaveChanges();

            }
            if (!context.Ogretmenler.Any())
            {
                context.Ogretmenler.Add(new Ogretmens
                {
                    OgretmenAd = "Emine",
                    OgretmenSoyad = "Kuş",
                    OgretmenDogumTarihi = DateOnly.FromDateTime(new DateTime(1986, 3, 20)),
                    OgretmenCinsiyet = "Kadın",
                    OgretmenTelefon = "04567147258",
                    OgretmenBaslamaTarihi = DateOnly.FromDateTime(new DateTime(2021,4,18)),
                    OgretmenUnvan="Doçent",
                    OgretmenGorusme="Pazartesi 14.00",
                    OgretmenOfis="Mühendislik Fakültesi Kat:3",
                    OgretmenEposta = "eminekus@gmail.com",
                    OgretmenParola = "147582",
                    OgretmenParolaOnayla = "1478582",
                    Adres = new Adres
                    {
                        AcıkAdres = "Mutlu Mahallesi Sokak: 7 No: 30 İzmir /Merkez",
                        Sehir = "İzmir",
                        Ilce = "Merkez",
                        Ulke = "Türkiye"
                    }
                });
                context.Ogretmenler.Add(new Ogretmens
                {
                    OgretmenAd = "Ahmet",
                    OgretmenSoyad = "Yılmaz",
                    OgretmenDogumTarihi = DateOnly.FromDateTime(new DateTime(1975, 5, 10)),
                    OgretmenCinsiyet = "Erkek",
                    OgretmenTelefon = "03456258369",
                    OgretmenBaslamaTarihi = DateOnly.FromDateTime(new DateTime(2015, 9, 3)),
                    OgretmenUnvan = "Profesör",
                    OgretmenGorusme = "Salı 10.00",
                    OgretmenOfis = "Edebiyat Fakültesi Kat:2",
                    OgretmenEposta = "ahmetyilmaz@gmail.com",
                    OgretmenParola = "123456",
                    OgretmenParolaOnayla = "123456",
                    Adres = new Adres
                    {
                        AcıkAdres = "Güzel Mahallesi Sokak: 15 No: 40 İstanbul / Üsküdar",
                        Sehir = "İstanbul",
                        Ilce = "Üsküdar",
                        Ulke = "Türkiye"
                    }
                });

                context.Ogretmenler.Add(new Ogretmens
                {
                    OgretmenAd = "Ayşe",
                    OgretmenSoyad = "Demir",
                    OgretmenDogumTarihi = DateOnly.FromDateTime(new DateTime(1980, 9, 25)),
                    OgretmenCinsiyet = "Kadın",
                    OgretmenTelefon = "0453698527",
                    OgretmenBaslamaTarihi = DateOnly.FromDateTime(new DateTime(2018, 6, 12)),
                    OgretmenUnvan = "Yardımcı Doçent",
                    OgretmenGorusme = "Çarşamba 13.00",
                    OgretmenOfis = "Fen Fakültesi Kat:1",
                    OgretmenEposta = "aysedemir@gmail.com",
                    OgretmenParola = "abcdef",
                    OgretmenParolaOnayla = "abcdef",
                    Adres = new Adres
                    {
                        AcıkAdres = "Bahçe Mahallesi Sokak: 3 No: 20 Ankara / Çankaya",
                        Sehir = "Ankara",
                        Ilce = "Çankaya",
                        Ulke = "Türkiye"
                    }
                });

                context.Ogretmenler.Add(new Ogretmens
                {
                    OgretmenAd = "Mustafa",
                    OgretmenSoyad = "Şahin",
                    OgretmenDogumTarihi = DateOnly.FromDateTime(new DateTime(1990, 12, 15)),
                    OgretmenCinsiyet = "Erkek",
                    OgretmenTelefon = "04557589456",
                    OgretmenBaslamaTarihi = DateOnly.FromDateTime(new DateTime(2019, 11, 8)),
                    OgretmenUnvan = "Öğretim Görevlisi",
                    OgretmenGorusme = "Perşembe 11.00",
                    OgretmenOfis = "Mimarlık Fakültesi Kat:4",
                    OgretmenEposta = "mustafasahin@gmail.com",
                    OgretmenParola = "654321",
                    OgretmenParolaOnayla = "654321",
                    Adres = new Adres
                    {
                        AcıkAdres = "Çiçek Mahallesi Sokak: 12 No: 25 İzmir / Bornova",
                        Sehir = "İzmir",
                        Ilce = "Bornova",
                        Ulke = "Türkiye"
                    }
                });
                context.SaveChanges();
            }
        }
    }
}