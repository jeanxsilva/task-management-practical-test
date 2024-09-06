using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public enum TaskStatusEnum
    {
        New = 0,
        Running = 5,
        Concluded = 999
    }

    public class TaskModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public TaskStatusEnum? Status { get; set; }
        public string DescriptionWithStatus
        {
            get
            {
                string normalizedStatus = null;
                switch (this.Status)
                {
                    case TaskStatusEnum.New:
                        normalizedStatus = "Novo";
                        break;
                    case TaskStatusEnum.Running:
                        normalizedStatus = "Em andamento";
                        break;
                    case TaskStatusEnum.Concluded:
                        normalizedStatus = "Concluido";
                        break;
                }

                return $"{this.Description} - [{normalizedStatus}]";
            }
        }
    }
}
