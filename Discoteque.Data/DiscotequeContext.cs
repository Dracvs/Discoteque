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
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Song> Songs{ get; set; }
    public DbSet<Tour> Tours{ get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        if(builder == null)
        {
            return;
        }

        builder.Entity<Artist>().ToTable("Artist").HasKey(k => k.Id);
        builder.Entity<Album>().ToTable("Album").HasKey(k => k.Id);
        builder.Entity<Song>().ToTable("Song").HasKey(k => k.Id);
        builder.Entity<Tour>().ToTable("Tour").HasKey(k => k.Id);
        base.OnModelCreating(builder);
    }
}