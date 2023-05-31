using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SongsApp.Models;
using SongsApp.Services.Interfaces;

namespace SongsApp.Controllers.Auth;

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly DatabaseContext _dbContext;
        private readonly IPasswordHasher _passwordHasher;
        
        public LoginController(IConfiguration config, DatabaseContext dbContext, IPasswordHasher passwordHasher)
        {
            _config = config;
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);
            
            if (user != null)
            {
                var token = GenerateToken(user);
                return Ok(token);
            }

            return NotFound("user not found");
        }

        // To generate token
        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        //To authenticate user
        private User Authenticate(UserLogin userLogin)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == userLogin.Username);
            
            if (user == null || ! _passwordHasher.VerifyPassword(user.Password, userLogin.Password))
            {
                return null;
            }

            return user;
        }
    }
