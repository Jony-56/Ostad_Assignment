using Assignment_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_3.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult DashBoard()
        {
            User user = new User();
            List<User> totalUser = user.ShowData();
            return View(totalUser);
        }
    }
}