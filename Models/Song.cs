using System.ComponentModel.DataAnnotations.Schema;

namespace SongsApp.Models;

public class Song
{
    public int Id { get; set; }
    public string Title { get; set; }

    public double Lenght { get; set; }
    
    public Album Album { get; set; }

    public Song()
    {
        
    }
    
    public Song(int id, string title, double lenght, Album album)
    {
        Id = id;
        Title = title;
        Lenght = lenght;
        Album = album;
    }
}