using System.Reflection.Metadata.Ecma335;
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
            if (userBo != null)
            {
                userModel = _mapper.Map<UserModel>(userBo);
                userModel.Password = null;
                GenericResponse<UserModel> response = new GenericResponse<UserModel>()
                {
                    StatusCode = 200,
                    ResponseData = userModel,
                    ResponseMessage = "Success"
                };
                return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, response);
            }
            else
            {
                GenericResponse<UserModel> response = new GenericResponse<UserModel>()
                {
                    StatusCode = 500,
                    ResponseData = null,
                    ErrorMessage = "Internal Server Error in adding the user"
                };
                return StatusCode(500, response);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserCredentialsModel credentials)
        {
            var credentialsBo = _mapper.Map<UserCredentialsBo>(credentials);
            string token = await _userService.Login(credentialsBo);
            GenericResponse<string> response = new GenericResponse<string>()
            {
                StatusCode = 200,
                ResponseData = token,
                ResponseMessage = "Success"
            };

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }
    }
}
