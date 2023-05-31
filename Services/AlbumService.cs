using SongsApp.Models;
using Microsoft.EntityFrameworkCore;
using SongsApp.Repositories.Interfaces;
using SongsApp.Services.Interfaces;

namespace SongsApp.Services;

public class AlbumService : IAlbumService
{
    private readonly IAlbumRepository _albumRepository;
    private readonly IAuthorRepository _authorRepository;

    public AlbumService(IAlbumRepository albumRepository, IAuthorRepository authorRepository)
    {
        _albumRepository = albumRepository;
        _authorRepository = authorRepository;
    }

    public async Task<IEnumerable<Album>> GetAllAlbums()
    {
        return await _albumRepository.GetAll();
    }

    public async Task<Album?> GetById(int id)
    {
        return await _albumRepository.GetById(id);
    }

    public async Task<Album> CreateAlbum(AlbumUpdate album)
    {
        var author = await _authorRepository.GetById(album.AuthorId);

        if (author == null)
        {
            throw new Exception("Author does not exist");
        }
        
        var newAlbum = new Album
        {
            Title = album.Title,
            ReleaseDate = album.ReleaseDate,
            Author = author
        };
        
        return await _albumRepository.Insert(newAlbum);
    }
    
    public async Task<int?> UpdateAlbum(int id, AlbumUpdate album)
    {
        var albumEntry = await GetById(id);
        
        if (albumEntry == null)
        {
            return null;
        }

        var author = await _authorRepository.GetById(album.AuthorId);

        if (author == null)
        {
            throw new Exception("Author does not exist");
        }

        return await _albumRepository.Update(album, albumEntry);
    }

    public async Task<bool> DeleteAlbum(int id)
    {
        var albumEntry = await GetById(id);
        
        if (albumEntry == null)
        {
            return false;
        }

        return await _albumRepository.Delete(albumEntry) > 0;
    }
}