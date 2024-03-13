using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using OBS_App.Data;

namespace OBS_App.Models
{
    //VeriTabanı Bağlantı yeri, Veritabanından Role Ve User Bilgilerini Alıyor. Aynı Zamanda DbContext in Üst Sınıfı IdentityDbContext.
    public class IdentityDataContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options)
        {
        }
        public DbSet<AkademikTakvim> AkademikTakvimler { get; set; }
        public DbSet<Bolum> Bolumler { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<Duyuru> Duyurular { get; set; }
        public DbSet<Fakulte> Fakulteler { get; set; }
        public DbSet<Ogrencis> Ogrenciler { get; set; }
        public DbSet<Not> Notlar { get; set; }
        public DbSet<Ogretmens> Ogretmenler { get; set; }
        public DbSet<OgretmenOgrenci> OgretmenOgrenciler { get; set; }
        public DbSet<DersOgrenci> DersOgrenciler { get; set; }
        public DbSet<OkulDonemDers> OkulDonemDersler { get; set; }
        public DbSet<Donem> Donemler { get; set; }
       
    }
}
