using ToanThangSite.Business.Core;
using ToanThangSite.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ToanThangSite.Entities.Core;

namespace ToanThangSite.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        public ActionResult ListAccount()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            string emailcookies = System.Web.HttpContext.Current.User.Identity.Name;
            if (!String.IsNullOrEmpty(emailcookies))
            {
                if (emailcookies != "admin")
                {
                    return RedirectToAction("ListOrder", "Order");
                }
                return RedirectToAction("Index", "Home");
            }
            return View(new LoginViewModel());
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string ReturnUrl)
        {

            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Username, model.Password))
                {
                    //FormsAuthentication.SetAuthCookie(model.Username, true);
                    if (model.Username != "admin")
                    {
                        return RedirectToAction("ListOrder", "Order");
                    }

                    if (ReturnUrl != null || ReturnUrl != string.Empty)
                        FormsAuthentication.RedirectFromLoginPage(model.Username, true);
                    else
                        FormsAuthentication.RedirectFromLoginPage(model.Username, true);
                }
                else
                {
                    ModelState.AddModelError("Email", "Sai tài khoản");
                    return View(model);
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult ChangePassword()
        {
            Account item = AccountBusiness.GetByID(HttpContext.User.Identity.Name);
            ChangePasswordViewModel model = new ChangePasswordViewModel();
            model.UserName = item.Username;
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (AccountBusiness.ChangePassword(model.UserName, model.NewPassWord))
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }

    }
}