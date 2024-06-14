using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskManagement.BLL.BOs;
using TaskManagement.BLL.Interfaces;
using TaskManagement.DAL.DTOs;
using TaskManagement.DAL.Interfaces;

namespace TaskManagement.BLL.Services
{
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<List<TaskBo>> GetAllTasks()
        {
            var taskDtos = await _taskRepository.GetAllTasks();
            var taskBos = _mapper.Map<List<TaskBo>>(taskDtos);
            return taskBos;
        }
        public async Task<bool> AddTask(TaskBo taskBo)
        {
            var taskDto = _mapper.Map<TaskDto>(taskBo);
            var result = await _taskRepository.AddTask(taskDto);
            return result;
        }
        public async Task<bool> UpdateTask(TaskBo taskBo)
        {
            var taskDto = _mapper.Map<TaskDto>(taskBo);
            var result = await _taskRepository.UpdateTask(taskDto);
            return result;
        }
    }
}
