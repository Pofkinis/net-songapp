using SongsApp.Models;

namespace SongsApp.Services.Interfaces;

public interface ISongService
{ 
     Task<IEnumerable<Song>> GetAllSongs();
     
     Task<Song> GetById(int id);

     Task<Song> CreateSong(Song song);
     
     Task<Song> UpdateSong(Song song);

     Task<bool> DeleteSong(int id);
}