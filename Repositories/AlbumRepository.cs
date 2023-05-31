using Microsoft.EntityFrameworkCore;
using SongsApp.Models;
using SongsApp.Repositories.Interfaces;

namespace SongsApp.Repositories;

public class AlbumRepository : IAlbumRepository
{
    private readonly DatabaseContext _context;

    public AlbumRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<Album?> GetById(int id)
    {
        return await _context.Albums
            .Include(a => a.Author)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Album>> GetAll()
    {
        return await _context.Albums
            .Include(a => a.Author)
            .ToListAsync();
    }

    public async Task<Album> Insert(Album album)
    {
        _context.Add(album);
        await _context.SaveChangesAsync();

        return album;
    }

    public async Task<int> Update(AlbumUpdate album, Album albumEntry)
    {
        _context.Entry(albumEntry).CurrentValues.SetValues(album);
        
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Delete(Album album)
    {
        _context.Albums.Remove(album);
         
        return await _context.SaveChangesAsync();
    }
}