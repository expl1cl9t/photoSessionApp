using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photoSessionApp.database
{
    class DataBaseWorker
    {
        public async Task<SqlDataReader> GetAllAappointments(SqlConnection connection)
        {
                await connection.OpenAsync();
                SqlCommand select = new SqlCommand("SELECT * FROM appointments", connection);
                SqlDataReader result = await select.ExecuteReaderAsync();
                await connection.CloseAsync();
                return result;
        }
    }
}
