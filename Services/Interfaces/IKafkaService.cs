using SongsApp.Models;

namespace SongsApp.Services.Interfaces;

public interface IKafkaService
{
    Task<ResponseModel> LikeSong(int songId, int userId);
    Task<ResponseModel> UnlikeSong(int songId, int userId);
}