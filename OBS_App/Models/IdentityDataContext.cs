using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace OBS_App.Models
{

    //VeriTabanı Bağlantı yeri, Veritabanından Role Ve User Bilgilerini Alıyor. Aynı Zamanda DbContext in Üst Sınıfı IdentityDbContext.
    public class IdentityDataContext : IdentityDbContext<AppUser, AppRole, string>
    {

        public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options)
        {


        }

    }
}
