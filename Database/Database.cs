using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public static class Database
    {
        private static readonly string _databaseName = "task_manager.db";

        public static void Configure()
        {
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databaseName)))
                Database.createTables();
        }

        public static SQLiteConnection EstablishConnection()
        {
            return new SQLiteConnection($"Data Source={_databaseName}");
        }

        private static void createTables()
        {
            using (var connection = new SQLiteConnection($"Data Source={_databaseName}"))
            {
                connection.Open();

                string sql = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database\\migration.txt"));
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}