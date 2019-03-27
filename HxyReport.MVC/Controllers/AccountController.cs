using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HxyReport.Services.DncUser;
using HxyReport_MVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;


namespace HxyReport_MVC.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly HxyUserManager _userManager;
        private readonly IDncUserService _dncUserService;

        public AccountController(HxyUserManager userManager, IDncUserService dncUserService)
        {
            _userManager = userManager;
            _dncUserService = dncUserService;
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindAsync(model.UserName, model.Password);

                if (user != null)
                {
                    await SignInAsync(user, model.RememberMe);

                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Helpers

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            var identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            if (isPersistent)
            {
                AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, identity);
            }
            else
            {
                AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTime.Now.AddHours(24) }, identity);
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion
    }
}