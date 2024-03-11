using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OBS_App.Data;
using OBS_App.Models;

namespace OBS_App.VeritabanıSeed
{
    public class DonemSeed
    {
        private static readonly string[] DonemAd = { "Güz", "Bahar" };

        public static async void DonemSeedTest(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityDataContext>();

            if (!context.Ogrenciler.Any())
            {

                for (int d = 1; d <= 8; d++)
                {

                    foreach (var donemad in DonemAd)
                    {

                        context.Donemler.Add(new Donem
                        {
                            DonemAd = donemad,
                            DonemYariyil = d,


                        });
                    }
                }

                context.Ogrenciler.Add(new Ogrencis
                {
                    OgrenciAd = "Kemal",
                    OgrenciTc = "13232132",
                    OgrenciSoyad = "Kılıç",
                    OgrenciEposta = "Ahmet@gmail.com",
                    OgrenciCinsiyet = "Erkek",
                    OgrenciSinif = 1,
                    OgrenciTelefon = "25135",
                    OgrenciParola = "asdasd",
                    OgrenciParolaOnayla = "asdasd",
                    OgrenciDanisman = 1,
                    OgrenciKayitTarihi = new DateOnly(2024, 05, 05),
                    OgrenciDogumTarihi = new DateOnly(2024, 05, 05),

                    Adres = new Adres
                    {
                        Ulke = "Türkiye",
                        Sehir = "Düzce",
                        Ilce = "Merkez",
                        AcıkAdres = "No:15"
                    },
                    OgrenciNumara = new OgrenciNumara
                    {
                        OgrenciNumarasi= "2235431",
                        Not = new Not
                        {
                            NotFinal = 0,
                            NotOdev = 0,
                            NotVize = 0,
                            NotTarihi = new DateOnly(2024, 05, 05),
                        },
                        Bolum = new Bolum
                        {
                            BolumAd = "Yönetim Bilişim Sistemleri",
                            BolumBaskani = "Recep",
                            Fakulte = new Fakulte
                            {

                                FakulteAd = "Yönetim Bilişim Sistemleri",
                                OlusturmaTarihi = new DateOnly(2024, 05, 05),
                            }
                        },
                        Fakulte = new Fakulte
                        {

                            FakulteAd = "Yönetim Bilişim Sistemleri",
                            OlusturmaTarihi = new DateOnly(2024, 05, 05),
                        }
                    }

                });

                context.SaveChanges();
            }
        }
    }
}
