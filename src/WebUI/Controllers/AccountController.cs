using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Здесь будет логика проверки учетных данных пользователя
                // Если учетные данные верны, перенаправляем пользователя на главную страницу
                return RedirectToAction("Index", "Home");
            }

            // Если модель не прошла валидацию, возвращаем её обратно в представление
            return View(model);
        }

        public IActionResult Logout()
        {
            // Здесь будет логика для выхода пользователя из системы
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            // Здесь будет логика для получения данных текущего пользователя
            var model = new UserProfileViewModel
            {
                // Заполните модель данными пользователя
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditProfile(UserProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Здесь будет логика для обновления данных пользователя
                // Если обновление прошло успешно, перенаправляем пользователя на страницу профиля с сообщением об успехе
                return RedirectToAction("Profile", new { message = "Your profile has been updated successfully." });
            }

            // Если модель не прошла валидацию, возвращаем её обратно в представление
            return View(model);
        }

        [HttpPost]
        public IActionResult ChangePassword(string currentPassword, string newPassword)
        {
            if (ModelState.IsValid)
            {
                if (newPassword.Length >= 8)
                {
                    // Здесь будет логика для изменения пароля пользователя
                    // Если изменение прошло успешно, перенаправляем пользователя на страницу профиля с сообщением об успехе
                    return RedirectToAction("Profile", new { message = "Your password has been changed successfully." });
                }
                else
                {
                    // Если новый пароль не удовлетворяет требованиям, возвращаем ошибку
                    ModelState.AddModelError("", "The new password must be at least 8 characters long.");
                }
            }
            else
            {
                // Если текущий пароль неверен, возвращаем ошибку
                ModelState.AddModelError("", "The current password is incorrect.");
            }

            // Возвращаем пользователя на страницу с формой смены пароля
            return View("ChangePassword");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Проверяем, существует ли пользователь с данным электронным адресом.
                // Это пример, так что мы просто предположим, что пользователь существует.

                // Генерируем токен сброса пароля (обычно это делается через сервис безопасности).
                var resetToken = "GeneratedResetToken";

                // Создаем ссылку для сброса пароля.
                var resetLink = Url.Action("ResetPassword", "Account", new { token = resetToken }, protocol: HttpContext.Request.Scheme);

                // Отправляем электронное письмо пользователю с этой ссылкой (здесь используется заглушка).
                // EmailService.SendResetPasswordEmail(model.Email, resetLink);

                // Перенаправляем пользователя на страницу с подтверждением отправки письма.
                return RedirectToAction("ForgotPasswordConfirmation");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ResetPassword(string token)
        {
            // Проверяем токен сброса (здесь используется заглушка).
            if (token == "GeneratedResetToken")
            {
                var model = new ResetPasswordViewModel { Token = token };
                return View(model);
            }

            // Если токен недействителен, перенаправляем пользователя на страницу с ошибкой.
            return RedirectToAction("ResetPasswordError");
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Проверяем токен сброса и обновляем пароль (здесь используется заглушка).
                // В реальном приложении здесь будет логика взаимодействия с базой данных.

                // Перенаправляем пользователя на страницу с подтверждением сброса пароля.
                return RedirectToAction("ResetPasswordConfirmation");
            }

            return View(model);
        }


        public IActionResult FacebookLogin(string returnUrl = null)
        {
            var redirectUrl = Url.Action("FacebookResponse", "Account", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Facebook", redirectUrl);
            return Challenge(properties, FacebookDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> FacebookResponse(string returnUrl = null)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            // Логика пост-аутентификации (например, связывание аккаунта Facebook с локальным аккаунтом)
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                // Успешный вход, перенаправляем пользователя
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // Если пользователь не найден, можно предложить ему создать новый аккаунт
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                var user = new IdentityUser { UserName = email, Email = email };
                var createResult = await _userManager.CreateAsync(user);
                if (createResult.Succeeded)
                {
                    await _userManager.AddLoginAsync(user, info);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    // Обработка ошибок при создании аккаунта
                }
            }
            return RedirectToAction(nameof(Login));
        }



        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }


    }
}