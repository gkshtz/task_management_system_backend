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
            var taskModels = _mapper.Map<List<TaskModel>>(taskBo);
            return Ok(taskModels);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] TaskModel taskModel)
        {
            var taskBo = _mapper.Map<TaskBo>(taskModel);
            var result = await _taskService.AddTask(taskBo);
            if (result)
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] TaskModel taskModel)
        {
            var taskBo = _mapper.Map<TaskBo>(taskModel);
            var result = await _taskService.UpdateTask(taskBo);
            if(result)
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] int id)
        {
            var result = await _taskService.DeleteTask(id);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}
