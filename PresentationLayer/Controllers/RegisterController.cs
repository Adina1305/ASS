using DataAccessLayer.Entities;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
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
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            // Verificăm dacă UserType este valid și realizăm setările corespunzătoare
            if (model.UserType == "Teacher")
            {
                model.Group = null;       // Setăm Group la null pentru profesori
                if (string.IsNullOrWhiteSpace(model.Discipline))
                {
                    ModelState.AddModelError("Discipline", "Discipline is required for teachers.");
                }
            }
            else if (model.UserType == "Student")
            {
                model.Discipline = null;  // Setăm Discipline la null pentru studenți
                if (string.IsNullOrWhiteSpace(model.Group))
                {
                    ModelState.AddModelError("Group", "Group is required for students.");
                }
            }

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    Password = model.Password,
                    UserType = model.UserType,
                    Group = model.UserType == "Student" ? model.Group : null,
                    Discipline = model.UserType == "Teacher" ? model.Discipline : null
                };

                var isSuccess = await _userService.RegisterUserAsync(user);
                if (isSuccess)
                {
                    if (user.UserType == "Student")
                    {
                        return RedirectToAction("StudentDashboard", "Dashboard");
                    }
                    else if (user.UserType == "Teacher")
                    {
                        return RedirectToAction("ProfesorDashboard", "Dashboard");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Utilizatorul deja există.");
                }
            }

            return View(model);
        }
    }
}
