using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager
{
    public class TaskService : ITaskService
    {
        private static SQLiteConnection _connection;

        public bool Delete(int id)
        {
            using (var connection = Database.EstablishConnection())
            {
                connection.Open();
                string sql = "DELETE FROM Task WHERE Id = @Id";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }

            return true;
        }

        public List<TaskModel> GetAll()
        {
            List<TaskModel> taskModels = new List<TaskModel>();

            using (var connection = Database.EstablishConnection())
            {
                connection.Open();

                string sql = "SELECT * FROM Task";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    DataTable dataTable = new DataTable();
                    using (SQLiteDataReader sqlDataReader = command.ExecuteReader())
                    {
                        dataTable.Load(sqlDataReader);
                    }

                    foreach (DataRow row in dataTable.Rows)
                    {
                        TaskModel taskModel = new TaskModel();

                        taskModel.Id = Convert.ToInt32(row["Id"].ToString());
                        taskModel.Description = row["Description"].ToString();
                        taskModel.Status = (TaskStatusEnum)Convert.ToInt32(row["TaskStatusId"].ToString());

                        taskModels.Add(taskModel);
                    }
                }
            }

            return taskModels;
        }

        public TaskModel GetById(int id)
        {
            TaskModel taskModel = null;

            using (var connection = Database.EstablishConnection())
            {
                connection.Open();

                string sql = "SELECT * FROM Task WHERE Id = @Id";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    DataTable dataTable = new DataTable();
                    using (SQLiteDataReader sqlDataReader = command.ExecuteReader())
                    {
                        dataTable.Load(sqlDataReader);
                    }

                    taskModel = new TaskModel();

                    taskModel.Id = Convert.ToInt32(dataTable.Rows[0]["Id"].ToString());
                    taskModel.Description = dataTable.Rows[0]["Description"].ToString();
                    taskModel.Status = (TaskStatusEnum)Convert.ToInt32(dataTable.Rows[0]["TaskStatusId"].ToString());
                }
            }

            return taskModel;
        }

        public void Insert(TaskModel t)
        {
            using (var connection = Database.EstablishConnection())
            {
                connection.Open();
                string sql = "INSERT INTO Task (Description, TaskStatusId) VALUES (@Description, @Status)";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Description", t.Description);
                    command.Parameters.AddWithValue("@Status", t.Status);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(TaskModel t)
        {
            using (var connection = Database.EstablishConnection())
            {
                connection.Open();

                string sql = "UPDATE Task SET Description = COALESCE(@Description, Description), TaskStatusId = COALESCE(@Status, TaskStatusId) WHERE Id = @Id";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Description", !string.IsNullOrWhiteSpace(t.Description) ? t.Description : null);
                    command.Parameters.AddWithValue("@Status", t.Status != null ? t.Status : DBNull.Value);
                    command.Parameters.AddWithValue("@Id", t.Id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}