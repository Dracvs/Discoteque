using Discoteque.Business.IServices;
using Discoteque.Data;
using Discoteque.Data.Models;

namespace Discoteque.Business.Services;

public class ArtistsService : IArtistsService
{
    private IUnitOfWork _unitOfWork;

    public ArtistsService(IUnitOfWork unitofWork)
    {
        _unitOfWork = unitofWork;
    }

    public async Task<Artist> CreateArtist(Artist artist)
    {
        await _unitOfWork.ArtistRepository.AddAsync(artist);
        await _unitOfWork.SaveAsync();
        return artist;
    }

    public async Task<IEnumerable<Artist>> GetArtistsAsync()
    {
        return await _unitOfWork.ArtistRepository.GetAllAsync();
    }

    public async Task<Artist> GetById(int id)
    {
        return await _unitOfWork.ArtistRepository.FindAsync(id);
    }

    public async Task<Artist> UpdateArtist(Artist artist)
    {
        await _unitOfWork.ArtistRepository.Update(artist);
        await _unitOfWork.SaveAsync();
        return artist;

    }
}