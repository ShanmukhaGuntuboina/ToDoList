using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            return await _taskService.GetAllTasks();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTasksByUserId(int id)
        {
            return await _taskService.GetTasksByUserId(id);
        }

        [HttpPost]
        [Route("RegisterTask")]
        public async Task<IActionResult> RegisterTask(TblTask tblTask)
        {
            return await _taskService.RegisterTask(tblTask);

        }

    }
}





