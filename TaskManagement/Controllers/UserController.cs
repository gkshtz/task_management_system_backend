using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.BLL.BOs;
using TaskManagement.BLL.Interfaces;
using TaskManagement.BLL.Services;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
            
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(UserModel userModel)
        {
            var userBo = await _userService.RegisterUser(_mapper.Map<UserBo>(userModel));
            if (userBo!=null)
            {
                return Ok(userBo);
            }
            else
                return StatusCode(500);
        }
    }
}
