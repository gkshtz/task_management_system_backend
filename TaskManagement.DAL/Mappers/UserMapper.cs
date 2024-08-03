using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskManagement.DAL.DTOs;
using TaskManagement.DAL.Entities;

namespace TaskManagement.DAL.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        { 
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
