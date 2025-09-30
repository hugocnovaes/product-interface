using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medTC.Infrastructure.Utils
{
    public class MSSQLDatabaseConnection : IMSSQLDatabaseConnection
    {
        private readonly IConfiguration config;
        public MSSQLDatabaseConnection(IConfiguration _config)
        {
            config = _config;
        }

        private SqlConnection GetConnection()
        {
            var userid = config.GetSection("ConnectionStrings")["User"];
            //var password = _decryptConfig.GetDatabasePassword();
            var password = config.GetSection("ConnectionStrings")["Password"];
            var host = config.GetSection("ConnectionStrings")["Host"];
            var port = config.GetSection("ConnectionStrings")["Port"];
            var database = config.GetSection("ConnectionStrings")["Database"];

            return new SqlConnection($"Server={host},{port};Database={database};User Id={userid};Password={password};TrustServerCertificate=True;");
        }

        public SqlConnection OpenConnection()
        {
            var con = GetConnection();
            con.Open();
            return con;
        }
    }
}
