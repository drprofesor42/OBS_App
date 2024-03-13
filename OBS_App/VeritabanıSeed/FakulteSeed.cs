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
                        FakulteAd = List[i]
                        
                    });
                    context.SaveChanges();
                }
            }


        }
    }
}