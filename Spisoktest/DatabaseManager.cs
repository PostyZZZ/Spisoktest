using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Spisoktest
{
    internal class DatabaseManager
    {
        private NpgsqlConnection connection;

        public DatabaseManager(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
        }

        public DataTable GetProductsData()
        {
            DataTable dt = new DataTable();

            try
            {
                connection.Open();
                string sql = "SELECT id, name, article, price, ImagePath FROM items";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connection);
                da.Fill(dt);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
    }
}
