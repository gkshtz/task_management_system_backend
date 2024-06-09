using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskManagement.BLL.BOs;
using TaskManagement.DAL.DTOs;

namespace TaskManagement.BLL.Mappers
{
    public class TasksMapper : Profile
    {
        public TasksMapper()
        {
            CreateMap<TaskDto,TaskBo>().ReverseMap();
        }
    }
}
