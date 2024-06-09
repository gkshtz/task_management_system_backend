using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskManagement.DAL.Data;
using TaskManagement.DAL.DTOs;
using TaskManagement.DAL.Entities;
using TaskManagement.DAL.Interfaces;

namespace TaskManagement.DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public TaskRepository(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<List<TaskDto>> GetAllTasks()
        {
            var tasks = _appDbContext.Tasks.ToList();
            return _mapper.Map<List<TaskDto>>(tasks);
        }
        public async Task<bool> AddTask(TaskDto taskDto)
        {
            var task = _mapper.Map<Tasks>(taskDto);
            _appDbContext.Tasks.Add(task);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
