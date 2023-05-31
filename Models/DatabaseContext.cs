using Microsoft.EntityFrameworkCore;

namespace SongsApp.Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }

    public DbSet<Song> Songs { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Album> Albums { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserSong> UserSongs { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title);
            entity.HasOne<Author>(e => e.Author);
        });
       
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName);
            entity.Property(e => e.LastName);
        });*/
    }
}