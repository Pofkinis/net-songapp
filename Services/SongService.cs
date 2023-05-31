using SongsApp.Models;
using Microsoft.EntityFrameworkCore;
using SongsApp.Repositories.Interfaces;
using SongsApp.Services.Interfaces;

namespace SongsApp.Services;

public class SongService : ISongService
{
    private readonly ISongRepository _songRepository;
    private readonly IAlbumRepository _albumRepository;

    public SongService(ISongRepository songRepository, IAlbumRepository albumRepository)
    {
        _songRepository = songRepository;
        _albumRepository = albumRepository;
    }

    public async Task<IEnumerable<Song>> GetAllSongs()
    {
        return await _songRepository.GetAll();
    }

    public async Task<Song?> GetById(int id)
    {
        return await _songRepository.GetById(id);
    }

    public async Task<Song> CreateSong(SongUpdate song)
    {
        var album = await _albumRepository.GetById(song.AlbumId);
        
        if (album == null)
        {
            throw new Exception("Album does not exist");
        }

        var newSong = new Song
        {
            Title = song.Title,
            Lenght = song.Lenght,
            Album = album
        };
        
        return await _songRepository.Insert(newSong);
    }

    public async Task<int?> UpdateSong(int id, SongUpdate song)
    {
        var songEntry = await GetById(id);

        if (songEntry == null)
        {
            return null;
        }
        
        var author = await _albumRepository.GetById(song.AlbumId);

        if (author == null)
        {
            throw new Exception("Album does not exist");
        }

        return await _songRepository.Update(song, songEntry);
    }

    public async Task<bool> DeleteSong(int id)
    {
        var songEntry = await GetById(id);
        
        if (songEntry == null)
        {
            return false;
        }

        return await _songRepository.Delete(songEntry) > 0;
    }
}