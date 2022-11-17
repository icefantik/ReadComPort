using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadComPort
{
    internal class Database
    {
        private static string nameDB = "database.db";
        private static string connectionString = $"Data Source={nameDB}";
        
        public static void ExecuteQuery(string query)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
        }
    }
}
