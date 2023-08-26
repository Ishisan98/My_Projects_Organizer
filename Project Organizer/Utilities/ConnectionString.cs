namespace Project_Organizer.Utilities
{
    public class ConnectionString
    {
        private IConfiguration _configuration;
        public static string connectionString;

        public ConnectionString(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }
        public static string CName
        {
            get => connectionString;
        }

    }
}
