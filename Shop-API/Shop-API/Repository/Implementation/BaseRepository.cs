using Microsoft.Data.SqlClient;

namespace api.Repositories.Implementations
{
    public class BaseRepository
    {
        protected IConfiguration _configuration;
        public static Func<IConfiguration, SqlConnection> ConnectionFactory = (configuration) => new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
