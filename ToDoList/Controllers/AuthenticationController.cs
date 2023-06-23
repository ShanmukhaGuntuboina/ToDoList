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
        public ActionResult<string> Authenticate(UserAuthDto _userData)
        {
                var resultLoginCheck = _context.TblUsers
                    .Where(e => e.UserName == _userData.UserName && e.Password == _userData.Password)
                    .FirstOrDefault();
                if (resultLoginCheck == null)
                {
                    return Unauthorized();
                }
                    var securityKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
                var signingCredentials = new SigningCredentials(
                    securityKey, SecurityAlgorithms.HmacSha256);

                var claimsForToken = new List<Claim>();


                var jwtSecurityToken = new JwtSecurityToken(
                    _configuration["Authentication:Issuer"],
                    _configuration["Authentication:Audience"],
                    claimsForToken,
                    DateTime.UtcNow,
                    DateTime.UtcNow.AddHours(1),
                    signingCredentials);

                var tokenToReturn = new JwtSecurityTokenHandler()
                   .WriteToken(jwtSecurityToken);

                return Ok(tokenToReturn);
            }
        }
    }
          

