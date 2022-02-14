using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using TaskTest.BLL.User;
using TaskTest.DAL.Entities;

namespace TaskTest.WebUi.Controllers
{
    [Route("api/Authorization")]
    [ApiController]

    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> RegisterAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var idUser = user.Id;
            return Ok(idUser);
        }
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new() { Email = model.Email, UserName = model.Email, };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        return NotFound(error);
                    }
                }
            }
            return Ok(model);
        }

        #region login
        [Route("Login")]
        [HttpGet]
        public IActionResult Login([FromBody] string returnUrl = null)
        {
            return Ok(new LoginModel { ReturnUrl = returnUrl });
        }

        [Route("Login")]
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);


                if (result.Succeeded)
                {
                    //проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Ok();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }

            return Ok();
        }
        [Route("Logout")]
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return Ok();
        }

        #endregion
    }
}
