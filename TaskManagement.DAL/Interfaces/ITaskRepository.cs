using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.DAL.DTOs;

namespace TaskManagement.DAL.Interfaces
{
    public interface ITaskRepository
    {
        public Task<List<TaskDto>> GetAllTasks();
        public Task<TaskDto> AddTask(TaskDto taskDto);
        public Task<bool> UpdateTask(TaskDto taskDto);

        public Task<bool> DeleteTask(int id);
    }
}
