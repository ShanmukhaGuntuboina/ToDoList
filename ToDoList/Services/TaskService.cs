using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class TaskService : ITaskService
    {
        private readonly ToDoListDbContext _context;

        public TaskService(ToDoListDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _context.TblTasks
                .Select(c => new TaskDto
                {
                    TaskId = c.TaskId,
                    TaskType = c.TaskType,
                    TaskName = c.TaskName,
                    CreatedByUser = c.CreatedByUser,
                    AssignedToUser = c.AssignedToUser,
                    TaskDueDate = c.TaskDueDate
                })
                .ToListAsync();
            return new OkObjectResult(tasks);
        }



        public async Task<IActionResult> GetTasksByUserId(int id)
        {
            var tasks = _context.TblTasks
            .Where(a => a.AssignedToUser == id)
            .ToList();

            var taskDTOs = tasks.Select(task => new TaskDto
            {

                TaskId = task.TaskId,
                TaskType = task.TaskType,
                TaskName = task.TaskName,
                CreatedByUser = task.CreatedByUser,
                AssignedToUser = task.AssignedToUser,
                TaskDueDate = task.TaskDueDate


            }).ToList();

            return new OkObjectResult(taskDTOs);
        }


        public async Task<IActionResult> RegisterTask(TblTask tblTask)
        {
         
            
                _context.TblTasks.Add(tblTask);
                await _context.SaveChangesAsync();

                return new CreatedAtActionResult("Register", "TblTask", new { id = tblTask.TaskId }, tblTask);
            }
        }
    }
    

