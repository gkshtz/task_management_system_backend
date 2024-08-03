using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskManagement.BLL.BOs;
using TaskManagement.DAL.DTOs;
using TaskManagement.DAL.Entities;

namespace TaskManagement.BLL.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserDto, UserBo>().ReverseMap();
        }
    }
}
