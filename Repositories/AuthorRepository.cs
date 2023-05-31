using Microsoft.EntityFrameworkCore;
using SongsApp.Models;
using SongsApp.Repositories.Interfaces;

namespace SongsApp.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly DatabaseContext _context;

    public AuthorRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<Author?> GetById(int id)
    {
        return await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Author>> GetAll()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task<Author> Insert(Author author)
    {
        _context.Add(author);
        await _context.SaveChangesAsync();

        return author;
    }

    public async Task<int> Update(AuthorUpdate author, Author authorEntry)
    {
        _context.Entry(authorEntry).CurrentValues.SetValues(author);
        
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Delete(Author author)
    {
        _context.Authors.Remove(author);
         
        return await _context.SaveChangesAsync();
    }
}