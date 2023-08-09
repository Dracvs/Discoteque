using System.Net;
using System;
using Discoteque.Business.IServices;
using Discoteque.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Discoteque.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TourController : ControllerBase
{
    private readonly ITourService _tourService;

    public TourController(ITourService tourService)
    {
        _tourService = tourService;
    }

    [HttpGet]
    [Route("GetTourById")]
    public async Task<IActionResult> GetTourById(int id)
    {
        var tour = await _tourService.GetTourById(id);
        return tour != null ? Ok(tour) : StatusCode(StatusCodes.Status404NotFound, "Tour not found");
    }

    [HttpGet]
    [Route("GetTours")]
    public async Task<IActionResult> GetTours()
    {
        var tours = await _tourService.GetToursAsync();
        return tours.Any() ? Ok(tours) : StatusCode(StatusCodes.Status404NotFound, "There were no tours found");
    }

    [HttpGet]
    [Route("GetToursByYear")]
    public async Task<IActionResult> GetToursByYear(int year)
    {
        var tours = await _tourService.GetToursByYear(year);
        return tours.Any() ? Ok(tours) : StatusCode(StatusCodes.Status404NotFound, "There were no tours found for this year");
    }

    [HttpGet]
    [Route("GetToursByArtist")]
    public async Task<IActionResult> GetToursByArtist(int artistId)
    {
        var tours = await _tourService.GetToursByArtist(artistId);
        return tours.Any() ? Ok(tours) : StatusCode(StatusCodes.Status404NotFound, "There were no tours by this artist");
    }

    [HttpGet]
    [Route("GetToursByCity")]
    public async Task<IActionResult> GetToursByCity(string city)
    {
        var tours = await _tourService.GetToursByCity(city);
        return tours.Any() ? Ok(tours) : StatusCode(StatusCodes.Status404NotFound, "No tours were found for this city");
    }

    [HttpPost]
    [Route("CreateTour")]
    public async Task<IActionResult> CreateTour(Tour tour)
    {
        var createdTour = await _tourService.CreateTour(tour);
        return createdTour != null ? Ok(createdTour) : StatusCode(StatusCodes.Status404NotFound, "The tour was not created");
    }

    [HttpPatch]
    [Route("UpdateTour")]
    public async Task<IActionResult> UpdateTour(Tour tour)
    {
        var updatedTour = await _tourService.UpdateTour(tour);
        return updatedTour != null ? Ok(updatedTour)    : StatusCode(StatusCodes.Status404NotFound, "The tour was not updated");
    }



}