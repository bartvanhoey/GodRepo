using JwtWebApiDotNet7.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtWebApiDotNet7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public static User User { get; set; } = new User() { UserName = "bartvanhoey", PasswordHash = "$2a$11$/FkpHRW1RLqxhhwmAGJXnOhlBBDEesq7uBBKRb4IQ2nChgSzPL.ZC"};

        public AuthController(IConfiguration configuration) => _configuration = configuration;


        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            User.UserName = request.UserName;
            User.PasswordHash = passwordHash;
            return Ok(User);
        }

        [HttpGet("login")]
        public ActionResult<User> Login(UserDto request)
        {
            if (User.UserName != request.UserName) return BadRequest("User not found");
            if (!BCrypt.Net.BCrypt.Verify(request.Password, User.PasswordHash)) return BadRequest("Invalid password");

            string token = CreateToken(User);

            return Ok(token);
        }

        private string CreateToken(User user){
            List<Claim> claims = new() { new Claim(ClaimTypes.Name, User.UserName)};
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: cred );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;


        }
         


    }
}