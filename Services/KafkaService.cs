using System.Security.Claims;
using Confluent.Kafka;
using Serilog;
using SongsApp.Models;
using SongsApp.Repositories.Interfaces;
using SongsApp.Services.Interfaces;

namespace SongsApp.Services;

public class KafkaService : IKafkaService
{
    private readonly ISongRepository _songRepository;
    private ProducerConfig _kafkaConfig;

    public KafkaService(ISongRepository songRepository)
    {
        _songRepository = songRepository;
        
        _kafkaConfig = new ProducerConfig
        {
            BootstrapServers = "localhost:9092",
        };
    }
    
    public async Task<ResponseModel> LikeSong(int songId, int userId)
    {
        var song = _songRepository.GetById(songId);

        if (song == null)
        {
            throw new Exception("Song does not exist");
        }

        using var producer = new ProducerBuilder<Null, string>(_kafkaConfig).Build();
        var msg = Newtonsoft.Json.JsonConvert.SerializeObject(new SongLikeMessage
        {
            UserId = userId,
            SongId = songId
        });
            
        var message = new Message<Null, string> { Value = msg };
        Log.Logger.Information("Sending like message");
        var deliveryReport = await producer.ProduceAsync("like", message);
        Log.Logger.Information("Kafka message delivered with content: {content}", msg);

        return new ResponseModel
        {
            IsSuccessful = true,
            Message = deliveryReport.Value
        };
    }
    
    public async Task<ResponseModel> UnlikeSong(int songId, int userId)
    {
        var song = _songRepository.GetById(songId);

        if (song == null)
        {
            throw new Exception("Song does not exist");
        }

        using var producer = new ProducerBuilder<Null, string>(_kafkaConfig).Build();
        var msg = Newtonsoft.Json.JsonConvert.SerializeObject(new SongLikeMessage
        {
            UserId = userId,
            SongId = songId
        });
            
        var message = new Message<Null, string> { Value = msg };
        Log.Logger.Information("Sending unlike message");
        var deliveryReport = await producer.ProduceAsync("unlike", message);
        Log.Logger.Information("Kafka message delivered with content: {content}", msg);

        return new ResponseModel
        {
            IsSuccessful = true,
            Message = deliveryReport.Value
        };
    }
}