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
                ViewBag.ErrorMessage = "Email sau parolă incorectă.";
                return View("Index"); 
            }

            if (user.UserType == "Student")
            {
                return RedirectToAction("StudentDashboard", "Dashboard");
            }
            else if (user.UserType == "Teacher")
            {
                return RedirectToAction("ProfesorDashboard", "Dashboard");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult StudentDashboard()
        {
            return View("Student"); 
        }

        public IActionResult ProfesorDashboard()
        {
            return View("Profesor"); 
        }
    }
}
