using SongsApp.Models;

namespace SongsApp.Services.Interfaces;

public interface IAlbumService
{ 
     Task<IEnumerable<Album>> GetAllAlbums();
     Task<Album?> GetById(int id);

     Task<Album> CreateAlbum(AlbumUpdate album);
     Task<int?> UpdateAlbum(int id, AlbumUpdate author);

     Task<bool> DeleteAlbum(int id);
}