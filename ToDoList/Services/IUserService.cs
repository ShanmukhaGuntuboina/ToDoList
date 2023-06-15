using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Services
{
    public interface IUserService
    {
        public Task<IActionResult> GetUser(int id);
        public Task<IActionResult> LoginUser(string username, string password);
        public Task<IActionResult> RegisterUser(TblUser tblUser);
    }
}
