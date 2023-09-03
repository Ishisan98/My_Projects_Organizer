using Project_Organizer.Models.Project;

namespace Project_Organizer.Interfaces
{
    public interface IModel
    {
        public bool CreateModel(string connectionString, Model newModel);

        public List<Model> GetAllModelsByProjectId(string connectionString, int projectId);
    }
}
