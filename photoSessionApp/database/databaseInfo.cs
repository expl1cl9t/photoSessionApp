using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photoSessionApp.database
{
    class DatabaseInfo
    {
        private string? _server_name;
        private string? _database_name;
        private string? _user_name;
        private string? _password;
        private string? _string_connection;
        public DatabaseInfo(string server_name, string database_name, string user_name,string password) {
            _server_name= server_name;
            _database_name= database_name;
            _user_name = user_name;
            _password=password;
        }
        public DatabaseInfo(string string_connection)
        {
            _string_connection= string_connection;
        }
        public SqlConnection getConnectionWithDataBase()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            if (_string_connection == null)
            {
                builder.DataSource = $"{_server_name}.database.windows.net";
                builder.UserID = _user_name;
                builder.Password = _password;
                builder.InitialCatalog = _database_name;
            }
            else
            {
                builder.ConnectionString= _string_connection;
            }
            return new SqlConnection(builder.ConnectionString);
        }
    }
}
