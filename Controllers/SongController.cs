using SongsApp.Models;
using Microsoft.AspNetCore.Mvc;
using SongsApp.Services.Interfaces;

namespace SongsApp.Controllers;

[ApiController]
public class SongController : ControllerBase
{
    private readonly ISongService _service;

    public SongController(ISongService service)
    {
        _service = service;
    }
    
    [HttpGet("songs")]
    public async Task<ActionResult<IEnumerable<Song>>> Get()
    {
        return Ok(await _service.GetAllSongs());
    }
    
    [HttpGet("songs/{id}")]
    public async Task<ActionResult<Song>> GetById(int id)
    {
        var song = await _service.GetById(id);

        if (song == null)
        {
            return NotFound();
        }

        return Ok(song);
    }
    
    [HttpPost("songs")]
    public async Task<ActionResult<Song>> Create(Song song)
    {
        await _service.CreateSong(song);
        
        return CreatedAtAction(nameof(Create), song);
    }
    
    [HttpPut("songs")]
    public async Task<ActionResult<Song>> Update(Song song)
    {
        var updatedSong = await _service.UpdateSong(song);
        
        if (updatedSong == null)
        {
            return NotFound();
        }

        return NoContent();
    }
    
    [HttpDelete("songs")]
    public async Task<ActionResult<Song>> Delete(int id)
    {
        var result = await _service.DeleteSong(id);
        
        if (result)
        {
            return NoContent();
        }

        return BadRequest();
    }
}