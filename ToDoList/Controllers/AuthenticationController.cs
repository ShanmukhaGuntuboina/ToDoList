using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoList.Models;

namespace ToDoList.Controllers
{

    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        ToDoListDbContext _context = new ToDoListDbContext();

        IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        [HttpPost]
        [Route("Authenticate the User")]
        public async Task<IActionResult> Authenticate(TblUser _userData)
        {
            if (_userData != null)
            {
                var resultLoginCheck = _context.TblUsers
                    .Where(e => e.UserName == _userData.UserName && e.Password == _userData.Password)
                    .FirstOrDefault();
                if (resultLoginCheck == null)
                {
                    return BadRequest("Invalid Credentials");
                }
                else
                {
                   

                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", _userData.UserId.ToString()),
                    };


                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);



                    return Ok(_userData);
                }
            }
            else
            {
                return BadRequest("No Data Posted");
            }
        }



    }
}


