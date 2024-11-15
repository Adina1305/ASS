using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserService _userService;

        public LoginController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string email, string password)
        {
            var user = await _userService.AuthenticateUserAsync(email, password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserType", user.UserType);
                HttpContext.Session.SetString("Email", user.Email);

                if (user.UserType == "Student")
                {
                    return RedirectToAction("StudentDashboard", "Dashboard");
                }
                else if (user.UserType == "Teacher")
                {
                    return RedirectToAction("ProfesorDashboard", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ViewData["ErrorMessage"] = "Email sau parolă incorectă.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
