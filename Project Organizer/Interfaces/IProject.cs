using Project_Organizer.Models.Project;

namespace Project_Organizer.Interfaces
{
    public interface IProject
    {
        public bool CreateNewProject (string connectionString, Project newProject);
        public List<Project> GetAllProjects (string connectionString);
        public Project GetProjectById(string connectionString, int id);
        public bool UpdateProject(string connectionString, Project project);
        public bool DeleteProjectById(string connectionString, int id);
    }
}
