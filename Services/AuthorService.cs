using System.Transactions;
using SongsApp.Models;
using Microsoft.EntityFrameworkCore;
using SongsApp.Repositories.Interfaces;
using SongsApp.Services.Interfaces;

namespace SongsApp.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<IEnumerable<Author>> GetAllAuthors()
    {
        return await _authorRepository.GetAll();
    }

    public async Task<Author?> GetById(int id)
    {
        return await _authorRepository.GetById(id);
    }

    public async Task<Author> CreateAuthor(Author author)
    {
        return await _authorRepository.Insert(author);
    }

    public async Task<int?> UpdateAuthor(int id, AuthorUpdate author)
    {
        var authorEntry = await GetById(id);
        
        if (authorEntry == null)
        {
            return null;
        }

        return await _authorRepository.Update(author, authorEntry);
    }


    public async Task<bool> DeleteAuthor(int id)
    {
        var authorEntry = await GetById(id);
        
        if (authorEntry == null)
        {
            return false;
        }

        return await _authorRepository.Delete(authorEntry) > 0;
    }
}