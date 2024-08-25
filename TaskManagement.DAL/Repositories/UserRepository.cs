using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagement.DAL.Data;
using TaskManagement.DAL.DTOs;
using TaskManagement.DAL.Entities;
using TaskManagement.DAL.Interfaces;

namespace TaskManagement.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public UserRepository(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }
        public async Task<UserDto> AddUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user = _appDbContext.Users.Add(user).Entity;
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<UserDto>(user); 
        }

        public async Task<UserDto> FetchUserByEmail(string email)
        {
            var user = await _appDbContext.Users.Where(x=> x.Email == email).FirstOrDefaultAsync();
            if(user == null)
            {
                return null;
            }
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
