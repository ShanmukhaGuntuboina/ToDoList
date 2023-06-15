using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Get User by ID")]
        public async Task<IActionResult> GetUser(int id)
        {
            return await _userService.GetUser(id);
        }

        [Route("Login")]
        [HttpGet]
        public async Task<IActionResult> LoginUser(string username, string password)
        {
            return await _userService.LoginUser(username, password);
        }

        [HttpPost("Register User")]
        public async Task<IActionResult> RegisterUser(TblUser tblUser)
        {
            return await _userService.RegisterUser(tblUser);

        }


    }
    }



