using System;
using Discoteque.Data.Models;
using Discoteque.Data.Dto;

namespace Discoteque.Business.IServices;

public interface ITourService
{
    Task<IEnumerable<Tour>> GetToursAsync();
    Task<Tour> GetTourById(int id);
    Task<IEnumerable<Tour>> GetToursByArtist(int ArtistId);
    Task<IEnumerable<Tour>> GetToursByYear(int year);
    Task<IEnumerable<Tour>> GetToursByCity(string city);
    Task<TourMessage> CreateTour(Tour tour);
    Task<Tour> UpdateTour(Tour tour);

}