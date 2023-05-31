using System.Security.Claims;
using SongsApp.Models;
using Microsoft.AspNetCore.Mvc;
using SongsApp.Services.Interfaces;

namespace SongsApp.Controllers;

[ApiController]
//[Authorize]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _service;

    public AuthorController(IAuthorService service)
    {
        _service = service;
    }
    
    [HttpGet("authors")]
    public async Task<ActionResult<IEnumerable<Author>>> Get()
    {
        var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Ok(await _service.GetAllAuthors());
    }
    
    [HttpGet("authors/{id}")]
    public async Task<ActionResult<Author>> GetById(int id)
    {
        var author = await _service.GetById(id);

        if (author == null)
        {
            return NotFound();
        }

        return Ok(author);
    }
    
    [HttpPost("authors")]
    public async Task<ActionResult<Author>> Create(Author author)
    {
        await _service.CreateAuthor(author);
        
        return CreatedAtAction(nameof(Create), author);
    }

    [HttpPut("authors/{id}")]
    public async Task<ActionResult<Author>> Update(int id, AuthorUpdate author)
    {
        var updatedAuthor = await _service.UpdateAuthor(id, author);

        if (updatedAuthor == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("authors")]
    public async Task<ActionResult<Author>> Delete(int id)
    {
        var result = await _service.DeleteAuthor(id);
        
        if (result)
        {
            return NoContent();
        }

        return BadRequest();
    }
}