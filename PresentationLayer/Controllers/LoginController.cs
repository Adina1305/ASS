using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserService _userService;

        public LoginController(UserService userService)
        {
            _userService = userService;
        }

        // GET: Login
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
                // În caz de autentificare cu succes, redirecționăm către Home/Index
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Adăugăm un mesaj de eroare dacă autentificarea a eșuat
                ViewData["ErrorMessage"] = "Invalid login attempt.";
            }

            return View();
        }
    }
}
