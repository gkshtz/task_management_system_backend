using AutoMapper;
using TaskManagement.BLL.BOs;
using TaskManagement.Models;

namespace TaskManagement.Mappers
{
    public class UserCredentialsMapper : Profile
    {
        public UserCredentialsMapper()
        {
            CreateMap<UserCredentialsBo, UserCredentialsModel>().ReverseMap();
        }
    }
}
