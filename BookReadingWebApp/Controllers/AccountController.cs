using BookReadingApp.Application.Interfaces;
using BookReadingApp.Core.Modals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace BookReadingApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountPageService;

        public AccountController(IAccountRepository accountPageService)
        {
            _accountPageService = accountPageService ?? throw new ArgumentNullException(nameof(accountPageService));
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("Sign-up")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [Route("Sign-up")]

        public async Task<IActionResult> SignUp(Signup user)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountPageService.CreateUser(user);
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(user);
                }
                ModelState.Clear();
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login(Login loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountPageService.LoginUser(loginViewModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                    return View(loginViewModel);
                }
            }
            return View();
        }

        [Authorize]
        [Route("log-Out")]

        public async Task<IActionResult> LogOut()
        {
            await _accountPageService.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
