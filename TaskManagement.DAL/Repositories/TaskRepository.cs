﻿using AutoMapper;
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
        public async Task<TaskDto> AddTask(TaskDto taskDto)
        {
            var task = _mapper.Map<Tasks>(taskDto);
            task = _appDbContext.Tasks.Add(task).Entity;
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<TaskDto>(task);
        }
        public async Task<bool> UpdateTask(TaskDto taskDto)
        {
            var task = _appDbContext.Tasks.Where(x => x.Id == taskDto.Id).FirstOrDefault();
            if (task != null)
            {
                if (!string.IsNullOrEmpty(taskDto.Name))
                {
                    task.Name = taskDto.Name;
                }
                if (!string.IsNullOrEmpty(taskDto.Description))
                {
                    task.Description = taskDto.Description;
                }
                if (taskDto.StartDate != DateTime.MinValue)
                {
                    task.StartDate = taskDto.StartDate;
                }
                if (taskDto.DueDate != DateTime.MinValue)
                {
                    task.DueDate = taskDto.DueDate;
                }
                task.Status = taskDto.Status;
                _appDbContext.Tasks.Update(task);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
        public async Task<bool> DeleteTask(int id)
        {
            var task = _appDbContext.Tasks.Where(x=>x.Id==id).FirstOrDefault();
            if(task!=null)
            {
                _appDbContext.Tasks.Remove(task);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
