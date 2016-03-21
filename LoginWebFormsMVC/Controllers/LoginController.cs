using LoginWebFormsMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LoginWebFormsMVC.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private AccessContext db = new AccessContext();

        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Login");
        }

        // GET: Login/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(Login login, String returnUrl)
        {
            if (db.LoginSet.Any(o => o.Nome.Equals(login.Nome) && o.Senha.Equals(login.Senha)))
            {
                FormsAuthentication.SetAuthCookie(login.Nome, false);

                if (Url.IsLocalUrl(returnUrl)
                    && returnUrl.Length > 1
                    && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//")
                    && !returnUrl.StartsWith("/\\")
                    && !returnUrl.Contains("Logout"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
                ModelState.AddModelError("", "usuário ou senha incorretos");

            return View();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View(db
                .LoginSet
                .Select(o => new ViewModels.Login
                {
                    Id = o.Id,
                    Nome = o.Nome
                })
                .ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}