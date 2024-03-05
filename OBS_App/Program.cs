using identy_user.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using OBS_App.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEmailSender, SmtpEmailSender>(i =>
new SmtpEmailSender(
    builder.Configuration["EmailSender:Host"],
    builder.Configuration.GetValue<int>("EmailSender:Port"),
    builder.Configuration.GetValue<bool>("EmailSender:EnableSSL"),
    builder.Configuration["EmailSender:Username"],
    builder.Configuration["EmailSender:Password"])
);

builder.Services.AddControllersWithViews();


//Veri Taban� Ba�lant�s�
builder.Services.AddDbContext<IdentityDataContext>(Options =>
{
    var configuration = builder.Configuration.GetConnectionString("mysql_connection");
    var version = new MySqlServerVersion(new Version(8, 0, 36));
    Options.UseMySql(configuration, version);
});


//Bu kod Identityuser ve Role ��in Gerekli olan �emay� projenin i�ine Dahil ediyor //AddEntityFrameworkStores<IdentityDataContext>(); blgilerin nerede deoplanaca��n� belirtir.
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<IdentityDataContext>().AddDefaultTokenProviders();



//Authentication configuration files ayarlar�n� yap�land�r�r(giri�)
builder.Services.Configure<IdentityOptions>(options =>
{
    //�e�itli �ifre Ayarlar�
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

    options.User.RequireUniqueEmail = false;
    //user giri�indeki harici kelimeleri engellemek i�in kullan�l�r
    //options.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnm@.";
    //5 sifre giri� hakk� var
    

    //Hesaba giri� yapmak i�in hesab� onaylatma
    options.SignIn.RequireConfirmedEmail = false;

   
});

//Authorization  configuration files ayarlar�n� yap�land�r�r(Giri�)
builder.Services.ConfigureApplicationCookie(options =>
{
    //Kullan�c� authorize oldu�unda gelecek sayfa
    options.LoginPath = "/Account/Login";
    //yetkisiz giri�lerde g�nderilen sayfa  
    options.AccessDeniedPath = "/Account/Accessdenied";
    //e�er kullan�c� sitede aktif ise cookie s�resi s�f�rlan�r
    options.SlidingExpiration = true;
    //cookie saklama zaman� - //oturum sonland�rma zaman�.
    options.ExpireTimeSpan = TimeSpan.FromDays(1);


});



var app = builder.Build();



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Projeye Kimlik giri�i Uygulamas�n� Ekler.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Index}/{id?}");

//IdentitySeed Verisini �al��t�r�r
IdentityUserSeed.IdentityTestUser(app);


IdentityRoleSeed.IdentityTestRole(app);

app.Run();
