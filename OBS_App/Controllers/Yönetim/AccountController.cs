using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using OBS_App.Models;
using OBS_App.ViewsModel;
using OBS_App.ViewsModel;
using System.Security.Cryptography.X509Certificates;


namespace OBS_App.Controllers.Yönetim
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        private readonly RoleManager<AppRole> _roleManager;

        private SignInManager<AppUser> _signInManager;

        private IEmailSender _emailSender;

        public AccountController(UserManager<AppUser> usermanager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IEmailSender emailSender)
        {
            _userManager = usermanager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailSender = emailSender;

        }

        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewsModel model)
        {
            if (ModelState.IsValid)
            {
                //kullanıcının emaili alınır
                var user = await _userManager.FindByEmailAsync(model.Email);



                if (user != null)
                {
                    //aktif kullanıcı varsa ilk çıkış yapılır.
                    await _signInManager.SignOutAsync();


                    //Pasword kontrol edili eğerki beni hatırla seçeneği işaretlenmişse true olarak kullanıcı oturumu kaydedilir.
                    var results = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);

                    if (results.Succeeded)
                    {
                        if (User.IsInRole("Admin"))
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        if (User.IsInRole("Ogretmen"))
                        {
                            return RedirectToAction("Index", "Ogretmen");
                        }
                        if (User.IsInRole("Ogrenci"))
                        {
                            return RedirectToAction("Index", "Ogrenci");
                        }

                        ModelState.AddModelError("", "*Lütfen Yöneticiniz İle Görüşünüz");


                    }
                    else
                    {

                        ModelState.AddModelError("", "*Parola Yanlış");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "*Bu Email Adresi İle Bir Hesap Bulunumadı");
                }


            }
            return View(model);
        }

        public async Task<IActionResult> ConfirmEmail(string Id, string token)
        {
            if (Id == null || token == null)
            {
                TempData["message"] = "Geçersiz token bilgisi";
                return View();
            }

            var user = await _userManager.FindByIdAsync(Id);

            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);

                if (result.Succeeded)
                {
                    TempData["message"] = "Hesabınız onaylandı";
                    return View();
                }
            }

            TempData["message"] = "Kullanıcı bulunamadı";
            return View();
        }

        public  IActionResult ForgotPassword()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                TempData["message"] = "Eposta adresinizi giriniz. ";
                return RedirectToAction("Login");
            }

            var user = await _userManager.FindByEmailAsync(Email);

            if (user == null)
            {
                TempData["message"] = "Eposta adresiyle eşleşen bir kayıt yok. ";
                return RedirectToAction("Login");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("ResetPassword", "Account", new { user.Id, token });

            await _emailSender.SendEmailAsync(Email, "Parola Sıfırlama", $"Parolanızı yenilemek için linke <a href='https://localhost:7274{url}'>tıklayınız.</a>");

            TempData["message"] = "Eposta adresinize gönderilen link ile şifrenizi sıfırlayabilirsiniz.";
            return RedirectToAction("Login");
        }

        public IActionResult ResetPassword(string Id, string token)
        {
            if (Id == null || token == null)
            {
                return RedirectToAction("Login");
            }

            var model = new ResetPasswordViewsModel { Token = token };
            return View(model);
        }

        
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewsModel model)
        {
            if (ModelState.IsValid)
            {
                var users = await _userManager.FindByEmailAsync(model.Email);
                if (users == null)
                {
                    TempData["message"] = "Kullanıcı bulunamadı ";
                    return RedirectToAction("ResetPassword");
                }
                var result = await _userManager.ResetPasswordAsync(users, model.Token, model.Password);

                if (result.Succeeded)
                {
                    TempData["message"] = "Şifre sıfırlandı yeni şifre ile giriş yapabilirsiniz";
                    return RedirectToAction("Login");
                }

                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()

        {

            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }
    }
}


