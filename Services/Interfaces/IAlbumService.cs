using SongsApp.Models;

namespace SongsApp.Services.Interfaces;

public interface IAlbumService
{ 
     Task<IEnumerable<Album>> GetAllAlbums();
     Task<Album> GetById(int id);

     Task<Album> CreateAlbum(Album album);
     Task<Album> UpdateAlbum(Album album);

     Task<bool> DeleteAlbum(int id);
}