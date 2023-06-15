using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Services
{
    public interface ITaskService
    {
        public Task<IActionResult> GetAllTasks();
        public Task<IActionResult> GetTasksByUserId(int id);
        public Task<IActionResult> RegisterTask(TblTask tblTask);
    }
}
