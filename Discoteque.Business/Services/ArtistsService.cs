using Discoteque.Business.IServices;
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

    public async Task<ArtistMessage> CreateArtist(Artist artist)
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
                return BuildResponse(HttpStatusCode.BadRequest, BaseMessageStatus.BAD_REQUEST_400);
            }

            await _unitOfWork.ArtistRepository.AddAsync(artist);
            await _unitOfWork.SaveAsync();
        }
        catch (Exception)
        {
            return BuildResponse(HttpStatusCode.BadRequest, BaseMessageStatus.INTERNAL_SERVER_ERROR_500);
        }

        return BuildResponse(HttpStatusCode.OK, BaseMessageStatus.OK_200, new(){artist});
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

    private static ArtistMessage BuildResponse(HttpStatusCode statusCode, string message)
    {
        return new ArtistMessage{
            Message = message,
            TotalElements = 0,
            StatusCode = statusCode                
        }; 
    }
    
    private static ArtistMessage BuildResponse(HttpStatusCode statusCode, string message, List<Artist> artist)
    {
        return new ArtistMessage{
            Message = message,
            TotalElements = artist.Count,
            StatusCode = statusCode,
            Artists = artist                
        }; 
    }
}