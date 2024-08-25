using AutoMapper;
using TaskManagement.BLL.BOs;
using TaskManagement.DAL.DTOs;
using TaskManagement.DAL.Entities;
using TaskManagement.Models;

namespace TaskManagement.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserModel, UserBo>().ReverseMap();
            CreateMap<UserDto, UserBo>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
