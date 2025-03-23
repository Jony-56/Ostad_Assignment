using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;  // Add this to import Account class


namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult ForgetPassword()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ForgetPassword(string Name)
        {
            Account account = new Account();
            if (string.IsNullOrEmpty(Name))
            {
                ViewBag.ErrorMessage = "Name  is required.";
                return View();
            }
            else if (account.ExistName(Name))
            {
                
                return RedirectToAction("RsestPass", new { Name  = Name });
            }
            return View();
        }

        public ActionResult RsestPass(string Name)
        {
            ViewBag.Name = Name;

            return View();
        }
        [HttpPost]
        public ActionResult RsestPass(string Name, string newPassword, string ConfirmPassword)
        {
            if (newPassword != ConfirmPassword)
            {
                ViewBag.error = "Enter the same password";
                return RedirectToAction("RsestPass", new { Name = Name });
            }
            Account account = new Account();
            bool updated = account.UpdatePass(newPassword, Name);
            if (updated)
            {
                ViewBag.msg = "Password upadted successfully";

                return RedirectToAction("Login", "Author");
            }
            else
            {
                ViewBag.error = "Error updating password. Try again.";
                return View();
            }


        }
    }

}