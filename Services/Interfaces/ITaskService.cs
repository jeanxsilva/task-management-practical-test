using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Services
{
    public interface ITaskService : IService<TaskModel, SQLiteConnection>
    {
    }
}
