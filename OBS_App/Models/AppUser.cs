using Microsoft.AspNetCore.Identity;

namespace OBS_App.Models
{
    //User bilgileri Bağlantısı
    public class AppUser : IdentityUser
    {
        public int Id { get; set; }


    }
}
