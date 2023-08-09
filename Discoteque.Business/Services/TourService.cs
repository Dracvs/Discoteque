using Discoteque.Business.IServices;
using Discoteque.Business.Utils;
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
    
    public async Task<BaseMessage<Tour>> CreateTour(Tour tour)
    {
        try
        {
            var artist = await _unitOfWork.ArtistRepository.FindAsync(tour.ArtistId);
            if (tour.TourDate.Year <= 2021 || artist == null)
            {
                return Utilities.BuildResponse<Tour>(HttpStatusCode.NotFound, BaseMessageStatus.BAD_REQUEST_400);
            }
            
            await _unitOfWork.TourRepository.AddAsync(tour);
            await _unitOfWork.SaveAsync();
        }
        catch (Exception)
        {
            return Utilities.BuildResponse<Tour>(HttpStatusCode.InternalServerError, BaseMessageStatus.INTERNAL_SERVER_ERROR_500);
        }
        
        return Utilities.BuildResponse(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Tour>(){tour});
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
}