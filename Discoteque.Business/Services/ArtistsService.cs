using Discoteque.Business.IServices;
using Discoteque.Business.Utils;
using Discoteque.Data;
using Discoteque.Data.Models;
using Discoteque.Data.Dto;
using System.Net;

namespace Discoteque.Business.Services;

public class ArtistsService : IArtistsService
{
    private readonly IUnitOfWork _unitOfWork;

    public ArtistsService(IUnitOfWork unitofWork)
    {
        _unitOfWork = unitofWork;
    }

    public async Task<BaseMessage<Artist>> CreateArtist(Artist artist)
    {
        var newArtist = new Artist{
            Name = artist.Name,
            IsOnTour = artist.IsOnTour,
            Label = artist.Label
        };
        
        try
        {
            if(artist.Name.Length > 100)
            {
                return Utilities.BuildResponse(HttpStatusCode.BadRequest, BaseMessageStatus.BAD_REQUEST_400, new List<Artist>());
            }

            await _unitOfWork.ArtistRepository.AddAsync(artist);
            await _unitOfWork.SaveAsync();
        }
        catch (Exception)
        {
            return Utilities.BuildResponse(HttpStatusCode.BadRequest, BaseMessageStatus.INTERNAL_SERVER_ERROR_500, new List<Artist>());
        }

        return Utilities.BuildResponse(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Artist>(){artist});
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