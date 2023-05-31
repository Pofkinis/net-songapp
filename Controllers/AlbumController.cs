using SongsApp.Models;
using Microsoft.AspNetCore.Mvc;
using SongsApp.Services.Interfaces;

namespace SongsApp.Controllers;

[ApiController]
public class AlbumController : ControllerBase
{
    private readonly IAlbumService _service;

    public AlbumController(IAlbumService service)
    {
        _service = service;
    }
    
    [HttpGet("albums")]
    public async Task<ActionResult<IEnumerable<Album>>> Get()
    {
        return Ok(await _service.GetAllAlbums());
    }
    
    [HttpGet("albums/{id}")]
    public async Task<ActionResult<Album>> GetById(int id)
    {
        var album = await _service.GetById(id);

        if (album == null)
        {
            return NotFound();
        }

        return Ok(album);
    }
    
    [HttpPost("albums")]
    public async Task<ActionResult<Album>> Create(AlbumUpdate album)
    {
        await _service.CreateAlbum(album);
        
        return CreatedAtAction(nameof(Create), album);
    }
    
    [HttpPut("albums/{id}")]
    public async Task<ActionResult<Album>> Update(int id, AlbumUpdate album)
    {
        var updatedAlbum = await _service.UpdateAlbum(id, album);
        
        if (updatedAlbum == null)
        {
            return NotFound();
        }

        return NoContent();
    }
    
    [HttpDelete("albums")]
    public async Task<ActionResult<Album>> Delete(int id)
    {
        var result = await _service.DeleteAlbum(id);
        
        if (result)
        {
            return NoContent();
        }

        return BadRequest();
    }
}