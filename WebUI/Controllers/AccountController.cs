using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;
using WebUI.Service.Account;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {

        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new LoginModel());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginModel loginModel)
        {
            LoginResponseViewModel responseViewModel = new LoginResponseViewModel();


            var response =  _accountService.LoginAsync(loginModel).Result;

            var loginResponse = JsonConvert.DeserializeObject<LoginAccessToken>( response.Content.ReadAsStringAsync().Result);

            Response.StatusCode = (int)response.StatusCode;

            if (response.IsSuccessStatusCode)
            {

                responseViewModel.IsRedirect = true;
                responseViewModel.RedirectUrl = Url.Action("Index", "Home");
                responseViewModel.ResponseViewModelList.Add(
              new ResponseViewModel
              {
                  Status = ResponseViewModelStatus.Success,
                  ResultDescription = "Giriş İşlemi Başarılı"
              }
              );
                var userClaims = new List<Claim>()
                {
                    new Claim("JwtToken", loginResponse.Token),
                    new Claim(ClaimTypes.NameIdentifier, loginResponse.UserId.ToString()),
                    new Claim(ClaimTypes.Name, loginResponse.UserName),

                 };

                var claimIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                var userPrincipal = new ClaimsPrincipal(new[] { claimIdentity });

                 HttpContext.SignOutAsync();
                 HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);




                return Json(responseViewModel);
            }

            responseViewModel.IsRedirect = false;

            return Json(responseViewModel);

        }


    }
}
