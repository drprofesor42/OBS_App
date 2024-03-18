using identy_user.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OBS_App.Hubs;
using OBS_App.Models;
using OBS_App.Veritaban�Seed;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEmailSender, SmtpEmailSender>(i =>
new SmtpEmailSender(
    builder.Configuration["EmailSender:Host"],
    builder.Configuration.GetValue<int>("EmailSender:Port"),
    builder.Configuration.GetValue<bool>("EmailSender:EnableSSL"),
    builder.Configuration["EmailSender:Username"],
    builder.Configuration["EmailSender:Password"])
);
//SignalR
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .SetIsOriginAllowed((host) => true)
               .AllowCredentials();
    });
});
builder.Services.AddSignalR();


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
    //Kullan�c�n�n authorize olmas� i�in gelecek sayfa
    options.LoginPath = "/Account/Login";
    //yetkisiz giri�lerde g�nderilen sayfa  
    options.AccessDeniedPath = "/Account/Accessdenied";
    //e�er kullan�c� sitede aktif ise cookie s�resi s�f�rlan�r
    options.SlidingExpiration = true;
    //cookie saklama zaman� - //oturum sonland�rma zaman�.
    options.ExpireTimeSpan = TimeSpan.FromDays(1);


});



var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Projeye Kimlik giri�i Uygulamas�n� Ekler.
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Ogretmen",
    pattern: "{area:exists}/{controller=Ogretmen}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Ogrenci",
    pattern: "{area:exists}/{controller=Ogrenci}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.MapHub<SignalRHub>("/signalrhub");
//SignalR istek bulunabilmek i�in
//localhost:1234/signalrhub

//IdentitySeed Verisini �al��t�r�r
IdentityUserSeed.IdentityTestUser(app);
IdentityRoleSeed.IdentityTestRole(app);
FakulteSeed.FakulteSeedTest(app);

app.Run();
