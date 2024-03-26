using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OBS_App.Areas.Admin.Controllers;
using OBS_App.Models;

namespace identy_user.Models
{
    public class IdentityUserSeed
    {
        public static async void IdentityTestUser(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityDataContext>();

            if (context.Database.GetAppliedMigrations().Any())
            {
                context.Database.Migrate();
            }

            var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var userRole = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

            var user = await userManager.FindByNameAsync("Misafir");

            if (user == null)
            {

                    user = new AppUser
                    {

                        UserName = "Admin",
                        Email = "ceylaanceyda06@gmail.com"

                    };

                    await userManager.CreateAsync(user, "123456789");
              
            }



            var adminUser = await userManager.FindByNameAsync("Admin");

            if (adminUser != null)

            {
                // Admin kullanıcısı bulundu, Admin rolünü atama
                await userManager.AddToRoleAsync(adminUser, "Admin");

            }

        }
    }
}
