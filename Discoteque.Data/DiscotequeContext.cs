using Microsoft.EntityFrameworkCore;
using Discoteque.Data.Models;
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
}