using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;  


namespace WebApplication1.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string txtName, string txtPassword)
        {
            // Validation for empty fields
            if (string.IsNullOrEmpty(txtName) || string.IsNullOrEmpty(txtPassword))
            {
                ViewBag.ErrorMessage = "Name and Password are required.";
                return View();
            }



            // Initialize member object for validation
            BaseMember member = new BaseMember();
            DataTable dt = member.validationMemberDtable(txtPassword, txtName);

            if (dt != null && dt.Rows.Count > 0)
            {
                // Successfully validated
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Invalid login
                ViewBag.ErrorMessage = "Invalid Name or Password.";
                return View();
            }
        }


    }

}