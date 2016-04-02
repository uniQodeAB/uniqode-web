using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using UniQode.Common;
using UniQode.Contracts.Services;
using UniQode.Models.Authentication;

namespace UniQode.Web.Controllers
{
    [RoutePrefix("auth")]
    public class AuthenticationController : OwinContextController
    {
        public AuthenticationController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        
        private readonly IAccountService _accountService;

        [Route("login")]
        public ActionResult Login(string returnUrl = null)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [Route("login")]
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            try
            {
                var account = _accountService.Login(model.Email, model.Password);

                Authentication.SignIn(
                        new AuthenticationProperties { IsPersistent = true },
                        new ClaimsIdentity(new List<Claim>
                        {
                            new Claim(ClaimTypes.Email, account.Email),
                            new Claim(ClaimTypes.Name, account.Name),
                            new Claim(ClaimTypes.NameIdentifier, account.Name)
                        }, "Application"));

                if (!string.IsNullOrWhiteSpace(model.ReturnUrl))
                    return Redirect(model.ReturnUrl);

                return RedirectToAction("Index", "Admin");
            }
            catch (ErrorCodeException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View();
        }

        [Route("logout")]
        public ActionResult Logout(string redirectUrl = null)
        {
            Authentication.SignOut("Application");
            Authentication.Challenge("Application");

            if (string.IsNullOrEmpty(redirectUrl))
                return RedirectToAction("Index", "Home");
            
            return Redirect(redirectUrl);
        }
    }
}