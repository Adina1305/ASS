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
            else
            {
                ViewData["ErrorMessage"] = "Invalid login attempt.";
            }

            return View();
        }

    }
}
