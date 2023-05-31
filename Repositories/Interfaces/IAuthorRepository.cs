using SongsApp.Models;

namespace SongsApp.Repositories.Interfaces;

public interface IAuthorRepository
{
    Task<Author?> GetById(int id);

    Task<IEnumerable<Author>> GetAll();

    Task<Author> Insert(Author author);

    Task<int> Update(AuthorUpdate author, Author authorEntry);
    
    Task<int> Delete(Author author);
}