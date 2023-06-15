using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class UserService : IUserService
    {
        private readonly ToDoListDbContext _context;
        public UserService(ToDoListDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> GetUser(int id)
        {
            var users = _context.TblUsers
            .Where(a => a.UserId == id)
            .ToList();

            var userDto = users.Select(user => new UserDto
            {

                UserId = user.UserId,
                UserName = user.UserName,
                Password = user.Password,
                UserTypeId = user.UserTypeId,

            }).ToList();

            return new OkObjectResult(userDto);
        }

        public async Task<IActionResult> LoginUser(string username, string password)
        {
            var user = await _context.TblUsers.SingleOrDefaultAsync(c => c.UserName == username);
            if (user == null || user.Password != password)
            {
                return new BadRequestObjectResult("Invalid Username or Password");
            }
            return new OkObjectResult(user);
        }

        public async Task<IActionResult> RegisterUser(TblUser tblUser)
        {
            if (TblUserExists(tblUser.UserName))
            {
                return new BadRequestObjectResult("User already Exists");
            }
            else
            {
                _context.TblUsers.Add(tblUser);
                await _context.SaveChangesAsync();

                return new CreatedAtActionResult("Register", "TblUser", new { id = tblUser.UserId }, tblUser);
            }
        }

        private bool TblUserExists(string username)
        {
            return _context.TblUsers.Any(e => e.UserName == username);
        }
    }
}
