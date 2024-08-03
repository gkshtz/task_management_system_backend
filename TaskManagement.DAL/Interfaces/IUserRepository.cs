using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.DAL.DTOs;

namespace TaskManagement.DAL.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserDto> AddUser(UserDto userDto);
    }
}
