using Microsoft.AspNetCore.Mvc;
using Project_Organizer.Models;

namespace Project_Organizer.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Dashboard ()
        {
            return View ();
        }

        
        public IActionResult CreateProject()
        {
            return View ();
        }

        [HttpPost]
        public IActionResult CreateProject(Project projectForm)
        {
            Project newProject = new Project();

            newProject.Project_Id = projectForm.Project_Id;
            newProject.Project_Name = projectForm.Project_Name;
            newProject.CreatedDate = DateTime.Now;
            newProject.ProjectStatus = true;

            return View("Dashboard");
        }
    }
}
