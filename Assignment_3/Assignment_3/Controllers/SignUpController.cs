using Assignment_3.Models;
using System.Web.Mvc;

namespace Assignment_3.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult signUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signUp(string firstName, string lastName, string email, string password, string confirmPassword, string gender, string role)
        {
            if (password != confirmPassword)
            {
                ViewBag.Error = "Password must be same";
                return View();
            }

            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                Gender = gender,
                Role = role
            };

            bool isSaved = user.SaveData(); // Call the SaveData method

            if (isSaved)
            {
                ViewBag.Message = "Registration Successful";
                return RedirectToAction("DashBoard", "DashBoard");
            }
            else
            {
                ViewBag.Error = "Error saving the user data!";
                return View();
            }
        }
    }
}
