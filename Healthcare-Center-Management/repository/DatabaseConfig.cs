using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.repository
{
    //Class which holds db reference, and opens a new connection.
    //Was created to be inherited whenever the db were needed.
    abstract class DatabaseConfig
    {
        protected readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionMySQL"].ConnectionString;
        protected MySqlConnection CreateConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
