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
            ViewBag.User = user;

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

        public IActionResult StudentDashboard()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                Console.WriteLine("Utilizatorul nu este autentificat");
                return RedirectToAction("Index", "Login");
            }

            var user = _userService.GetUserDetailsAsync(userId.Value).Result;
            if (user == null)
            {
                Console.WriteLine("Nu s-au găsit date pentru utilizatorul cu ID-ul " + userId);
                return RedirectToAction("Index", "Login");
            }

            ViewBag.User = user;
            return View("Student");  
        }

        public IActionResult ProfesorDashboard()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                Console.WriteLine("Utilizatorul nu este autentificat");
                return RedirectToAction("Index", "Login");
            }

            var user = _userService.GetUserDetailsAsync(userId.Value).Result;
            if (user == null)
            {
                Console.WriteLine("Nu s-au găsit date pentru utilizatorul cu ID-ul " + userId);
                return RedirectToAction("Index", "Login");
            }

            ViewBag.User = user;
            return View("Profesor");  
        }



    }

}