using AutoMapper;
using TaskManagement.DAL.DTOs;
using TaskManagement.DAL.Entities;

namespace TaskManagement.DAL.Mappers
{
    public class TasksMapper : Profile
    {
        public TasksMapper()
        {
            CreateMap<Tasks, TaskDto>().ReverseMap();
        }
    }
}
