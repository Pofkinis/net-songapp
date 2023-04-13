using SongsApp.Models;

namespace SongsApp.Services.Interfaces;

public interface IAuthorService
{ 
     Task<IEnumerable<Author>> GetAllAuthors();
     Task<Author> GetById(int id);

     Task<Author> CreateAuthor(Author author);
     Task<Author> UpdateAuthor(Author author);

     Task<bool> DeleteAuthor(int id);
}