using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;


namespace ShipmentTrackingService.Infrastructure.Data
{
    public class ShipmentDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ShipmentDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }

}
