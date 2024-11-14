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
                // For now, just return to Home
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View();
        }
    }
}
