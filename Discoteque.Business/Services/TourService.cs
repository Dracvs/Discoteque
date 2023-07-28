using Discoteque.Business.IServices;
using Discoteque.Data;
using Discoteque.Data.Models;
using Discoteque.Data.Dto;
using Microsoft.EntityFrameworkCore.Query;
using System.Net;

namespace Discoteque.Business.Services;

public class TourService : ITourService
{
    private readonly IUnitOfWork _unitOfWork;

    public TourService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<TourMessage> CreateTour(Tour tour)
    {
        try
        {
            var artist = await _unitOfWork.ArtistRepository.FindAsync(tour.ArtistId);
            if (tour.TourDate.Year <= 2021 || artist == null)
            {
                return BuildResponse(HttpStatusCode.NotFound, BaseMessageStatus.BAD_REQUEST_400);
            }
            
            await _unitOfWork.TourRepository.AddAsync(tour);
            await _unitOfWork.SaveAsync();
        }
        catch (Exception)
        {
            return BuildResponse(HttpStatusCode.InternalServerError, BaseMessageStatus.INTERNAL_SERVER_ERROR_500);
        }
        
        return BuildResponse(HttpStatusCode.OK, BaseMessageStatus.OK_200, new(){tour});
    }

    public async Task<Tour> GetTourById(int id)
    {
        return await _unitOfWork.TourRepository.FindAsync(id);
    }

    public async Task<IEnumerable<Tour>> GetToursAsync()
    {
        return await _unitOfWork.TourRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Tour>> GetToursByArtist(int artistId)
    {
        return await _unitOfWork.TourRepository.GetAllAsync(x => x.ArtistId == artistId, includeProperties: new Artist().GetType().Name);
    }

    public async Task<IEnumerable<Tour>> GetToursByCity(string city)
    {
        return await _unitOfWork.TourRepository.GetAllAsync(x => x.Equals(city));
    }

    public async Task<IEnumerable<Tour>> GetToursByYear(int year)
    {
        return await _unitOfWork.TourRepository.GetAllAsync(x => x.TourDate.Year == year);
    }

    public async Task<Tour> UpdateTour(Tour tour)
    {
        await _unitOfWork.TourRepository.Update(tour);
        await _unitOfWork.SaveAsync();
        return tour;
    }

    private static TourMessage BuildResponse(HttpStatusCode statusCode, string message)
    {
        return new TourMessage{
            Message = message,
            TotalElements = 0,
            StatusCode = statusCode                
        }; 
    }
    
    private static TourMessage BuildResponse(HttpStatusCode statusCode, string message, List<Tour> tours)
    {
        return new TourMessage{
            Message = message,
            TotalElements = tours.Count,
            StatusCode = statusCode,
            Tours = tours                
        }; 
    }
}