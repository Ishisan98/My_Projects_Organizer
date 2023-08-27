using Dapper;
using Project_Organizer.Interfaces;
using Project_Organizer.Models.Project;
using System.Data;
using System.Data.SqlClient;

namespace Project_Organizer.Repositories
{
    public class ProjectRepository : IProject
    {
        public bool CreateNewProject(string connectionString, Project newProject)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO Projects ( Project_Name, Description, Created_Date, Project_Status) " +
                            "VALUES (@ProjectName, @Description, @CreatedDate, @ProjectStatus)";
                var parameters = new
                {
                    ProjectName = newProject.Project_Name,
                    Description = newProject.Description,
                    CreatedDate = newProject.Created_Date,
                    ProjectStatus = newProject.Project_Status
                };

                try
                {
                    connection.Execute(query, parameters);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
                
            }
        }



        public List<Project> GetAllProjects (string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM Projects";

                try
                {
                    var projects = connection.Query<Project>(query);
                    List<Project> result = projects.ToList();
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
        }


        public Project GetProjectById (string connectionString, int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM Projects WHERE Project_Id = @Id";
                var parameters = new
                {
                    Id = id
                };

                try
                {
                    Project project = connection.QuerySingle<Project>(query, parameters);
                    return project;
                }
                catch (Exception ex)
                {
                Console.WriteLine(ex.ToString());
                return null;
                }

            }
        }


        public bool UpdateProject (string connectionString, Project project)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "UPDATE Projects SET Project_Name = @ProjectName, Description = @Description, Created_Date = @CreatedDate, Project_Status = @ProjectStatus " +
                            "WHERE Project_Id = @ProjectId";
                var parameters = new
                {
                    ProjectId = project.Project_Id,
                    ProjectName = project.Project_Name,
                    Description = project.Description,
                    CreatedDate = project.Created_Date,
                    ProjectStatus = project.Project_Status
                };

                try
                {
                    connection.Execute(query, parameters);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }

            }
        }


        public bool DeleteProjectById (string connectionString, int id) 
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "DELETE FROM Projects WHERE Project_Id = @ProjectId";
                var parameters = new
                {
                    ProjectId = id
                };

                try
                {
                    connection.Execute(query, parameters);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }

            }
        }
    }


}
