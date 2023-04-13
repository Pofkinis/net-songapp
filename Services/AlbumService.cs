using SongsApp.Models;
using Microsoft.EntityFrameworkCore;
using SongsApp.Services.Interfaces;

namespace SongsApp.Services;

public class AlbumService : IAlbumService
{
    private DatabaseContext _context;

    public AlbumService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Album>> GetAllAlbums()
    {
        return await _context.Albums.ToListAsync();
    }

    public async Task<Album> GetById(int id)
    {
        return await _context.Albums.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Album> CreateAlbum(Album album)
    {
        _context.Add(album);
        await _context.SaveChangesAsync();

        return album;
    }
    
    public async Task<Album> UpdateAlbum(Album album)
    {
        var albumEntry = await GetById(album.Id);

        if (albumEntry == null)
        {
            return null;
        }

        albumEntry = album;
        _context.Albums.Update(albumEntry);
        await _context.SaveChangesAsync();

        return album;
    }

    public async Task<bool> DeleteAlbum(int id)
    {
        var albumEntry = await GetById(id);
        
        if (albumEntry == null)
        {
            return false;
        }

        _context.Albums.Remove(albumEntry);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }
}