using Microsoft.AspNetCore.Identity;

namespace OBS_App.Models
{
    //User bilgileri Bağlantısı
    public class AppUser : IdentityUser
    {
        public string? DuyuruName { get; set; }


    }
}
