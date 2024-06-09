using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.BLL.BOs;

namespace TaskManagement.BLL.Interfaces
{
    public interface ITaskService
    {
        public Task<List<TaskBo>> GetAllTasks();
        public Task<bool> AddTask(TaskBo task);
    }
}
