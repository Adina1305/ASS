using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserService _userService;

        public DashboardController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userService.AuthenticateUserAsync(email, password);

            if (user == null)
            {
                ModelState.AddModelError("", "Email sau parolă incorectă.");
                return View();
            }

            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserType", user.UserType);
            HttpContext.Session.SetString("Email", user.Email);

            Response.Cookies.Append("IsLoggedIn", "true", new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddHours(1),
                HttpOnly = true
            });

            if (user.UserType == "Student")
            {
                return RedirectToAction("StudentDashboard", "Dashboard");
            }
            else if (user.UserType == "Teacher")
            {
                return RedirectToAction("ProfesorDashboard", "Dashboard");
            }

            return RedirectToAction("Index", "Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("IsLoggedIn");
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> StudentDashboard()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var user = await _userService.GetUserDetailsAsync(userId.Value);

            if (user != null)
            {
                ViewBag.User = user;
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            return View("Student");
        }

        public async Task<IActionResult> ProfesorDashboard()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var user = await _userService.GetUserDetailsAsync(userId.Value);

            if (user != null)
            {
                ViewBag.User = user;
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            return View("Profesor");
        }
    }
}
