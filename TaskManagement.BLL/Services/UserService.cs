using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.BLL.BOs;
using TaskManagement.BLL.Interfaces;
using TaskManagement.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using TaskManagement.DAL.DTOs;


namespace TaskManagement.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<UserBo> _passwordHasher;
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = new PasswordHasher<UserBo>();
            _mapper = mapper;
        }
        public async Task<UserBo> RegisterUser(UserBo userBo)
        {
            userBo.password = _passwordHasher.HashPassword(userBo, userBo.password);
            var userDto = _mapper.Map<UserDto>(userBo);
            userDto = await _userRepository.AddUser(userDto);
            return _mapper.Map<UserBo>(userDto);
        }
    }
}
