using Microsoft.Data.SqlClient;
using System.Data;


namespace AsyncJisaDemo.Data
{
    public class ApplicationDbContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public ApplicationDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection() =>new SqlConnection(connectionString);
    }
}
