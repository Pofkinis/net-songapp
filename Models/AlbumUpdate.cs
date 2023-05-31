using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace SongsApp.Models;

public class AlbumUpdate
{
    public string Title { get; set; }
    
    public DateTime ReleaseDate { get; set; }
    
    public int AuthorId { get; set; }
}