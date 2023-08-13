using Microsoft.AspNetCore.Mvc;
using Project_Organizer.Models.Project;

namespace Project_Organizer.Controllers
{
    public class ProjectController : Controller
    {
        public static List<Project> projects = new List<Project> ();


        // View Dashboard //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IActionResult Dashboard ()
        {
            ViewBag.ProjectsList = projects;
            return View ();
        }


        
        // Create New Project //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
            newProject.Created_Date = DateTime.Now;
            newProject.Description = projectForm.Description;
            newProject.Project_Status = true;

            projects.Add(newProject);

            //return View("Dashboard");
            return RedirectToAction("Dashboard","Project");
        }
    }
}
