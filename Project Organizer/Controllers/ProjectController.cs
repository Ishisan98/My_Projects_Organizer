using Microsoft.AspNetCore.Mvc;
using Project_Organizer.Interfaces;
using Project_Organizer.Models.Project;
using Project_Organizer.Utilities;

namespace Project_Organizer.Controllers
{
    public class ProjectController : Controller
    {
        public static List<Project> projects = new List<Project> ();

        private readonly IProject _projectInterface;
        private readonly IConfiguration _configuration;
        public static string connectionString;

        public ProjectController (IProject projectInterface, IConfiguration configuration)
        {
            _configuration = configuration;
            _projectInterface = projectInterface;
            connectionString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }




        // View Dashboard /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IActionResult Dashboard ()
        {
            List<Project> projects = _projectInterface.GetAllProjects(connectionString);
            ViewBag.ProjectsList = projects;
            return View ();
        }


        
        // Create New Project //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IActionResult CreateProject()
        {
            return View ();
        }

        [HttpPost]
        public IActionResult CreateProject(Project projectForm)
        {
            Project newProject = new Project();

            newProject.Project_Name = projectForm.Project_Name;
            newProject.Description = projectForm.Description;
            newProject.Created_Date = projectForm.Created_Date;
            newProject.Project_Status = true;

            _projectInterface.CreateNewProject(connectionString, newProject);

            return RedirectToAction("Dashboard","Project");
        }



        // Get Project by Id /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IActionResult GetProjectByProjectId (int id)
        {
            Project project = _projectInterface.GetProjectById(connectionString,id);
            if (project != null)
            {
                ViewBag.Project = project;
                return View("ProjectDetails");
            }
            return RedirectToAction("Dashboard", "Project");
        }



        // Update Project ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IActionResult UpdateProject (int id)
        {
            Project project = _projectInterface.GetProjectById (connectionString,id);
            if (project != null)
            {
                ViewBag.Project = project;
                return View("UpdateProject");
            }
            return RedirectToAction("Dashboard", "Project");
        }

        [HttpPost]
        public IActionResult UpdateProject (Project projectForm)
        {
            bool check = _projectInterface.UpdateProject(connectionString,projectForm);

            return RedirectToAction("GetProjectByProjectId", "Project", new { id = projectForm.Project_Id });
        }



        // Delete Project /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IActionResult DeleteProjectById (int id)
        {
            bool check = _projectInterface.DeleteProjectById(connectionString,id);
            return RedirectToAction("Dashboard", "Project");
        }
    }
}
