using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SongsApp.Controllers.ActionFilters;
using SongsApp.Models;
using SongsApp.Services.Interfaces;

namespace SongsApp.Controllers.Auth;

[ApiController]
public class RegistrationApi : ControllerBase
{
    private readonly DatabaseContext _dbContext;
    private readonly IPasswordHasher _passwordHasher;

    public RegistrationApi(DatabaseContext dbContext, IPasswordHasher passwordHasher)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
    }

    [HttpPost("register")]
    //[UniqueUsername] // Apply the UniqueEmail action filter to validate email uniqueness
    public async Task<IActionResult> Register(User model)
    {
        // Hash the password before saving it
        string hashedPassword = _passwordHasher.HashPassword(model.Password);

        // Create a new User entity
        var user = new User
        {
            Username = model.Username,
            Password = hashedPassword,
            Role = model.Role,
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return Ok("User registered successfully.");
    }
}