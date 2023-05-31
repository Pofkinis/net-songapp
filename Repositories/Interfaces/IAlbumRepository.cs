using SongsApp.Models;

namespace SongsApp.Repositories.Interfaces;

public interface IAlbumRepository
{
    Task<Album?> GetById(int id);

    Task<IEnumerable<Album>> GetAll();

    Task<Album> Insert(Album album);

    Task<int> Update(AlbumUpdate album, Album albumEntry);
    
    Task<int> Delete(Album album);
}