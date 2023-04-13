using SongsApp.Models;
using Microsoft.EntityFrameworkCore;
using SongsApp.Services.Interfaces;

namespace SongsApp.Services;

public class SongService : ISongService
{
    private DatabaseContext _context;

    public SongService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Song>> GetAllSongs()
    {
        return await _context.Songs.ToListAsync();
    }

    public async Task<Song> GetById(int id)
    {
        return await _context.Songs.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Song> CreateSong(Song song)
    {
        _context.Add(song);
        await _context.SaveChangesAsync();

        return song;
    }

    public async Task<Song> UpdateSong(Song song)
    {
        var songEntry = await GetById(song.Id);

        if (songEntry == null)
        {
            return null;
        }

        songEntry = song;
        _context.Songs.Update(songEntry);
        await _context.SaveChangesAsync();

        return song;
    }

    public async Task<bool> DeleteSong(int id)
    {
        var songEntry = await GetById(id);
        
        if (songEntry == null)
        {
            return false;
        }

        _context.Songs.Remove(songEntry);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }
}