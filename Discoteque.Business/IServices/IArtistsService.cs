using System;
using Discoteque.Data.Models;
using Discoteque.Data.Dto;

namespace Discoteque.Business.IServices
{
    public interface IArtistsService
    {
        Task<IEnumerable<Artist>> GetArtistsAsync();
        Task<Artist> GetById(int id);
        Task<ArtistMessage> CreateArtist(Artist artist);
        Task<Artist> UpdateArtist(Artist artist);
    }
}