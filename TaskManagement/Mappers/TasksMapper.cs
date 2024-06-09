using System.ComponentModel;
using AutoMapper;
using TaskManagement.BLL.BOs;
using TaskManagement.DAL.DTOs;
using TaskManagement.DAL.Entities;
using TaskManagement.Models;

namespace TaskManagement.Mappers
{
    public class TasksMapper : Profile
    {
        public TasksMapper()
        {
            CreateMap<TaskModel, TaskBo>().ReverseMap();
            CreateMap<TaskDto, TaskBo>().ReverseMap();
            CreateMap<Tasks, TaskDto>().ReverseMap();
        }
    }
}
