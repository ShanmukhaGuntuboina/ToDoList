using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("Get all tasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            return await _taskService.GetAllTasks();
        }

        [HttpGet("Get tasks by userId")]
        public async Task<IActionResult> GetTasksByUserId(int id)
        {
            return await _taskService.GetTasksByUserId(id);
        }

        [HttpPost("Create a task")]
        public async Task<IActionResult> RegisterTask(TblTask tblTask)
        {
            return await _taskService.RegisterTask(tblTask);

        }

    }
}





