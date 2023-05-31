using SongsApp.Models;

namespace SongsApp.Repositories.Interfaces;

public interface ISongRepository
{
    Task<Song?> GetById(int id);

    Task<IEnumerable<Song>> GetAll();

    Task<Song> Insert(Song song);

    Task<int> Update(SongUpdate song, Song songEntry);
    
    Task<int> Delete(Song song);
}