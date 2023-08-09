using Discoteque.Data.Models;
using Discoteque.Data.IRepositories;

namespace Discoteque.Data;

public interface IUnitOfWork
{
    IRepository<int, Artist> ArtistRepository{get;}
    IRepository<int, Album> AlbumRepository{get;}
    IRepository<int, Song> SongRepository{get;}
    IRepository<int, Tour> TourRepository{get;}
    Task SaveAsync();
}