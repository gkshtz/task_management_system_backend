using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.BLL.BOs;
using TaskManagement.BLL.Interfaces;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;
        public TaskController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var taskBo = await _taskService.GetAllTasks();
            var taskModels = _mapper.Map<List<TaskModel>?>(taskBo);
            GenericResponse<List<TaskModel>> response = new GenericResponse<List<TaskModel>>
            {
                StatusCode = 200,
                ResponseData = taskModels,
                ResponseMessage = "Success"
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] TaskModel taskModel)
        {
            var taskBo = _mapper.Map<TaskBo>(taskModel);
            var result = await _taskService.AddTask(taskBo);
            taskModel = _mapper.Map<TaskModel>(result);
            GenericResponse<TaskModel> response = new GenericResponse<TaskModel>
            {
               StatusCode = 200,
               ResponseData = taskModel,
               ResponseMessage = "Success"
            };
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] TaskModel taskModel)
        {
            var taskBo = _mapper.Map<TaskBo>(taskModel);
            var result = await _taskService.UpdateTask(taskBo);

            if (result)
            {
                GenericResponse<bool> response = new GenericResponse<bool>
                {
                    StatusCode = 200,
                    ResponseData = true,
                    ResponseMessage = "Success"
                };
                return Ok(response);
            }
            else
            {
                GenericResponse<bool> response = new GenericResponse<bool>
                {
                    StatusCode = 404,
                    ResponseData = false,
                    ResponseMessage = "Record Not Found"
                };
                return NotFound(response);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] int id)
        {
            var result = await _taskService.DeleteTask(id);
            if (result)
            {
                GenericResponse<bool> response = new GenericResponse<bool>
                {
                    StatusCode = 200,
                    ResponseData = true,
                    ResponseMessage = "Success"
                };
                return Ok(response);
            }
            else
            {
                GenericResponse<bool> response = new GenericResponse<bool>
                {
                    StatusCode = 404,
                    ResponseData = false,
                    ResponseMessage = "Record Not Found"
                };
                return NotFound(response);
            }
        }
    }
}
