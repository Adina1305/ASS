using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer; 
using DataAccessLayer;
using DataAccessLayer.Entities; 

public class ProfesorController : Controller
{
    private readonly ITaskService _taskService;
    private readonly ISubjectService _subjectService;

    public ProfesorController(ITaskService taskService, ISubjectService subjectService)
    {
        _taskService = taskService;
        _subjectService = subjectService;
    }

    public IActionResult Dashboard()
    {
        var subjects = _subjectService.GetAllSubjects();
        ViewBag.Subjects = subjects;

        return View();
    }

    [HttpPost]
    public IActionResult AddTask(string Title, DateTime DueDate, int SubjectId)
    {
        if (ModelState.IsValid)
        {
            var task = new Tasks
            {
                Title = Title,
                DueDate = DueDate,
                TeacherId = (int)HttpContext.Session.GetInt32("UserId"), 
                SubjectId = SubjectId
            };

            _taskService.Add(task); 

            return RedirectToAction("Dashboard");
        }
        return View();
    }

    [HttpPost]
    public IActionResult AddSubject(string Name)
    {
        if (ModelState.IsValid)
        {
            var subject = new Subject
            {
                Name = Name,
                TeacherId = (int)HttpContext.Session.GetInt32("UserId") 
            };

            _subjectService.AddSubject(subject);

            return RedirectToAction("Dashboard");
        }
        return View();
    }


}
