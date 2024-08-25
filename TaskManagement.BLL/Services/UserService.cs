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
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TaskManagement.Utils.Exceptions;
using TaskManagement.DAL.Entities;
using Microsoft.AspNetCore.Authentication;
using Azure.Identity;


namespace TaskManagement.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<UserBo> _passwordHasher;
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordHasher<UserBo> passwordHasher, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<string> Login(UserCredentialsBo userCredentialsBo)
        {
            var userDto = await _userRepository.FetchUserByEmail(userCredentialsBo.Email);
            if(userDto == null)
            {
                throw new ResourceNotFoundException("User with this email does not exist");
            }
            var result = _passwordHasher.VerifyHashedPassword(null, userDto.Password, userCredentialsBo.Password);
            var userBo = _mapper.Map<UserBo>(userDto);
            if(result == PasswordVerificationResult.Success)
            {
                string token = GenerateToken(userBo);
                return token;
            }
            else
            {
                throw new FailedAuthenticationException("User Not Authenticated");
            }
        }

        public async Task<UserBo> RegisterUser(UserBo userBo)
        {
            userBo.Password= _passwordHasher.HashPassword(null, userBo.Password);
            var userDto = _mapper.Map<UserDto>(userBo);
            userDto = await _userRepository.AddUser(userDto);
            return _mapper.Map<UserBo>(userDto);
        }

        private string GenerateToken(UserBo user)
        {
            var claims = new List<Claim> {
                        new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                        new Claim("UserId", user.Id.ToString()!),
                        new Claim("Name", user.Name),
                        new Claim("Email",user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn
                );
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }
}
