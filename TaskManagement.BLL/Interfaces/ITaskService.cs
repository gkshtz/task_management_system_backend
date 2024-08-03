using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.BLL.BOs;
using TaskManagement.DAL.DTOs;

namespace TaskManagement.BLL.Interfaces
{
    public interface ITaskService
    {
        public Task<List<TaskBo>> GetAllTasks();
        public Task<TaskBo> AddTask(TaskBo task);
        public Task<bool> UpdateTask(TaskBo taskBo);
        public Task<bool> DeleteTask(int id);
    }
}
