using System.ComponentModel.DataAnnotations.Schema;

namespace SongsApp.Models;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Author()
    {
        
    }
    public Author(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
}