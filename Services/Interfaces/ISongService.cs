using SongsApp.Models;

namespace SongsApp.Services.Interfaces;

public interface ISongService
{ 
     Task<IEnumerable<Song>> GetAllSongs();
     
     Task<Song?> GetById(int id);

     Task<Song> CreateSong(SongUpdate song);
     
     Task<int?> UpdateSong(int id, SongUpdate song);

     Task<bool> DeleteSong(int id);
}