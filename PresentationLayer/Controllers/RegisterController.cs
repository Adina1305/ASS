using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserService _userService;

        public RegisterController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var user = new User();
            return View();
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(User model)
        {
            if (ModelState.IsValid)
            {
                var isSuccess = await _userService.RegisterUserAsync(model);
                if (isSuccess)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User already exists.");
                }
            }
            return View(model);
        }
    }
}
