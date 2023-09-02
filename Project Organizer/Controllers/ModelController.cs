using Microsoft.AspNetCore.Mvc;
using Project_Organizer.Models;

namespace Project_Organizer.Controllers
{
    public class ModelController : Controller
    {

        // View Models //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IActionResult ViewModels (int projectId)
        {
            return View();
        }



        // Add New Model //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IActionResult CreateModel ()
        {
            return View();
        }

        public IActionResult CreateModel (Model modelForm)
        {
            return RedirectToAction("Dashboard", "Project");
        }


    }
}
