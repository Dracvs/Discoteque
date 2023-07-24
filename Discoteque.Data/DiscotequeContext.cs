using Microsoft.EntityFrameworkCore;
using Discoteque.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Discoteque.Data;


public class DiscotequeContext : DbContext
{
    public DiscotequeContext(
        DbContextOptions<DiscotequeContext> options) 
        : base(options)
    {
        
    }

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Album> Albums { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        if(builder == null)
        {
            return;
        }

        builder.Entity<Artist>().ToTable("Artist").HasKey(k => k.Id);
        builder.Entity<Album>().ToTable("Album").HasKey(k => k.Id);
        base.OnModelCreating(builder);
    }
}