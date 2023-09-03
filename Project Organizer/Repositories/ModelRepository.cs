using Dapper;
using Project_Organizer.Interfaces;
using Project_Organizer.Models.Project;
using Project_Organizer.Utilities;
using System.Data;
using System.Data.SqlClient;

namespace Project_Organizer.Repositories
{
    public class ModelRepository : IModel
    {
        public bool CreateModel(string connectionString, Model newModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var procedure = "Models_StoredProcedures";
                var parameters = new
                {
                    ModelId = 0,
                    ModelName = newModel.Model_Name,
                    Description = newModel.Description,
                    ProjectId = newModel.Project_Id,

                    Process = "CreateModel"
                };

                try
                {
                    connection.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }


        public List<Model> GetAllModelsByProjectId(string connectionString, int projectId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var procedure = "Models_StoredProcedures";
                var parameters = new
                {
                    ModelId = 0,
                    ModelName = "",
                    Description = "",
                    ProjectId = projectId,

                    Process = "GetModelsByProjectId"
                };

                try
                {
                    var models = connection.Query<Model>(procedure, parameters, commandType: CommandType.StoredProcedure);
                    List<Model> result = models.ToList();

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
        }




    }
}
