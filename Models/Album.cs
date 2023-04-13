using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace SongsApp.Models;

public class Album
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public DateTime ReleaseDate { get; set; }
    
    public Author Author { get; set; }
    
    public Album()
    {
        
    }
    public Album(int id, string title, DateTime releaseDate, Author author)
    {
        Id = id;
        Title = title;
        ReleaseDate = releaseDate;
        Author = author;
    }
}