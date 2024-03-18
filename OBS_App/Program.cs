using identy_user.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OBS_App.Hubs;
using OBS_App.Models;
using OBS_App.VeritabanýSeed;
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


//Veri Tabaný Baðlantýsý
builder.Services.AddDbContext<IdentityDataContext>(Options =>
{
    var configuration = builder.Configuration.GetConnectionString("mysql_connection");
    var version = new MySqlServerVersion(new Version(8, 0, 36));
    Options.UseMySql(configuration, version);
});


//Bu kod Identityuser ve Role Ýçin Gerekli olan Þemayý projenin içine Dahil ediyor //AddEntityFrameworkStores<IdentityDataContext>(); blgilerin nerede deoplanacaðýný belirtir.
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<IdentityDataContext>().AddDefaultTokenProviders();



//Authentication configuration files ayarlarýný yapýlandýrýr(giriþ)
builder.Services.Configure<IdentityOptions>(options =>
{
    //Çeþitli Þifre Ayarlarý
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

    options.User.RequireUniqueEmail = false;
    //user giriþindeki harici kelimeleri engellemek için kullanýlýr
    //options.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnm@.";
    //5 sifre giriþ hakký var
    

    //Hesaba giriþ yapmak için hesabý onaylatma
    options.SignIn.RequireConfirmedEmail = false;

   
});

//Authorization  configuration files ayarlarýný yapýlandýrýr(Giriþ)
builder.Services.ConfigureApplicationCookie(options =>
{
    //Kullanýcýnýn authorize olmasý için gelecek sayfa
    options.LoginPath = "/Account/Login";
    //yetkisiz giriþlerde gönderilen sayfa  
    options.AccessDeniedPath = "/Account/Accessdenied";
    //eðer kullanýcý sitede aktif ise cookie süresi sýfýrlanýr
    options.SlidingExpiration = true;
    //cookie saklama zamaný - //oturum sonlandýrma zamaný.
    options.ExpireTimeSpan = TimeSpan.FromDays(1);


});



var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Projeye Kimlik giriþi Uygulamasýný Ekler.
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
//SignalR istek bulunabilmek için
//localhost:1234/signalrhub

//IdentitySeed Verisini çalýþtýrýr
IdentityUserSeed.IdentityTestUser(app);
IdentityRoleSeed.IdentityTestRole(app);
FakulteSeed.FakulteSeedTest(app);

app.Run();
