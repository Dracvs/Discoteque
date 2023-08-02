using System;
using Discoteque.Data.Models;
using Discoteque.Data.Dto;

namespace Discoteque.Business.IServices
{
    public interface IArtistsService
    {
        Task<IEnumerable<Artist>> GetArtistsAsync();
        Task<Artist> GetById(int id);
        Task<BaseMessage<Artist>> CreateArtist(Artist artist);
        Task<BaseMessage<Artist>> CreateArtistsInBatch(List<Artist> artists);
        Task<Artist> UpdateArtist(Artist artist);
    }
}