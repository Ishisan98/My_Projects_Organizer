using Microsoft.AspNetCore.Mvc;
using Project_Organizer.Interfaces;
using Project_Organizer.Models.Project;

namespace Project_Organizer.Controllers
{
    public class ModelController : Controller
    {

        private readonly IModel _modelInterface;
        private readonly IConfiguration _configuration;
        public static string connectionString;

        public ModelController(IModel modelInterface, IConfiguration configuration)
        {
            _configuration = configuration;
            _modelInterface = modelInterface;
            connectionString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }


        // Manage Models //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IActionResult ManageModels (int id)
        {
            List<Model> models = _modelInterface.GetAllModelsByProjectId(connectionString, id);
            ViewBag.Models = models;
            ViewBag.ProjectId = id;

            return View();
        }

        [HttpPost]
        public IActionResult ManageModels (Model modelForm)
        {
            Model newModel = new Model();
            newModel.Model_Name = modelForm.Model_Name;
            newModel.Description = modelForm.Description;
            newModel.Project_Id = modelForm.Project_Id;

            bool check = _modelInterface.CreateModel(connectionString, newModel);

            return RedirectToAction("ManageModels", "Model", new { id = modelForm.Project_Id });
        }




    }
}
