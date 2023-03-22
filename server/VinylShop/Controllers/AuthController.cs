using Application.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace VinylShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<string> GetTestMessage()
        {
            return "Hello, world!";
        }

        [HttpPost]
        public ActionResult<string> CreateToken(PersonRequestDto personRequest)
        { 
            if (personRequest.Login == "login" &&
                personRequest.Password == "password")
            {
                var issuer = _configuration.GetValue<string>("Jwt:ISSUER");
                var audience = _configuration.GetValue<string>("Jwt:AUDIENCE");
                var key = Encoding.ASCII.GetBytes(
                    _configuration.GetValue<string>("Jwt:KEY"));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, "User"),
                        new Claim(JwtRegisteredClaimNames.Email, "Email"),
                        new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), 
                        SecurityAlgorithms.HmacSha512Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var stringToken = tokenHandler.WriteToken(token);
                return stringToken;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
