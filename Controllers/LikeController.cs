using System.Security.Claims;
using Confluent.Kafka;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SongsApp.Services.Interfaces;

namespace SongsApp.Controllers;

[ApiController]
[Authorize]
public class LikeController : ControllerBase
{
    private readonly IKafkaService _kafkaService;
    
    public LikeController(IKafkaService kafkaService)
    {
        _kafkaService = kafkaService;
    }
    
    [HttpPost("like/{songId}")]
    public async Task<ActionResult> Store(int songId)
    {
        var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var response = await _kafkaService.LikeSong(songId, Int32.Parse(userId));

        return Ok(response.Message);
    }
    
    [HttpPost("unlike/{songId}")]
    public async Task<ActionResult> Delete(int songId)
    {
        var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var response = await _kafkaService.UnlikeSong(songId, Int32.Parse(userId));

        return Ok(response.Message);
    }
}