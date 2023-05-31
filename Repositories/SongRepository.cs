using Microsoft.EntityFrameworkCore;
using SongsApp.Models;
using SongsApp.Repositories.Interfaces;

namespace SongsApp.Repositories;

public class SongRepository : ISongRepository
{
    private readonly DatabaseContext _context;

    public SongRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<Song?> GetById(int id)
    {
        return await _context.Songs.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Song>> GetAll()
    {
        return await _context.Songs.ToListAsync();
    }

    public async Task<Song> Insert(Song song)
    {
        _context.Add(song);
        await _context.SaveChangesAsync();

        return song;
    }

    public async Task<int> Update(SongUpdate song, Song songEntry)
    {
        _context.Entry(songEntry).CurrentValues.SetValues(song);
        
        return await _context.SaveChangesAsync();
    }
    
    public async Task<int> Delete(Song song)
    {
         _context.Songs.Remove(song);
         
         return await _context.SaveChangesAsync();
    }
}