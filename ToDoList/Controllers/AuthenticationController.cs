using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ToDoList.Controllers
{

    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        // we won't use this outside of this class, so we can scope it to this namespace
        public class AuthenticationRequestBody
        {
            public string? UserName { get; set; }
            public string? Password { get; set; }
        }

        private class UserInfo
        {
            public int UserId { get; set; }
            public string UserName { get; set; } = null!;

            public string Password { get; set; } = null!;


            public UserInfo(
                string userName,
                string password)
            {

                UserName = userName;
                Password = password;
            }

        }
    }
}

        //public AuthenticationController(IConfiguration configuration)
        //{
        //    _configuration = configuration ??
        //        throw new ArgumentNullException(nameof(configuration));
        //}

        //[HttpPost("authenticate")]
        //public ActionResult<string> Authenticate(
        //    AuthenticationRequestBody authenticationRequestBody)
        //{
        //    var user = ValidateUserCredentials(
        //        authenticationRequestBody.UserName,
        //        authenticationRequestBody.Password);

        //    if (user == null)
        //    {
        //        return Unauthorized();
        //    }

//            var securityKey = new SymmetricSecurityKey(
//                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
//            var signingCredentials = new SigningCredentials(
//                securityKey, SecurityAlgorithms.HmacSha256);

//            var claimsForToken = new List<Claim>();


//            var jwtSecurityToken = new JwtSecurityToken(
//                _configuration["Authentication:Issuer"],
//                _configuration["Authentication:Audience"],
//                claimsForToken,
//                DateTime.UtcNow,
//                DateTime.UtcNow.AddHours(1),
//                signingCredentials);

//            var tokenToReturn = new JwtSecurityTokenHandler()
//               .WriteToken(jwtSecurityToken);

//            return Ok(tokenToReturn);
//        }

//    }

//}
        
