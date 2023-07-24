using System.Data.SqlTypes;
using Discoteque.Data.Models;
using Discoteque.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace Discoteque.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlbumController : ControllerBase
{
    private readonly IAlbumService _albumService;

    public AlbumController(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    [HttpGet]
    [Route("GetAlbums")]
    public async Task<IActionResult> GetAlbums(bool areReferencesLoaded = false)
    {
        var albums = await _albumService.GetAlbumsAsync(areReferencesLoaded);
        return Ok(albums);
    }

    [HttpGet]
    [Route("GetAlbumById")]
    public async Task<IActionResult> GetById(int id)
    {
        var album = await _albumService.GetById(id);
        return Ok(album);
    }

    [HttpGet]
    [Route("GetAlbumsByYear")]
    public async Task<IActionResult> GetAlbumsByYear(int year)
    {
        var albums = await _albumService.GetAlbumsByYear(year);
        return albums.Any() ? Ok(albums) : StatusCode(StatusCodes.Status404NotFound,  "There was no albums found in this year");
    }

    [HttpGet]
    [Route("GetAlbumsByYearRAnge")]
    public async Task<IActionResult> GetAlbumsByYearRange(int initialYear, int yearRange)
    {
        var albums = await _albumService.GetAlbumsByYearRange(initialYear, yearRange);
        return albums.Any() ? Ok(albums) : StatusCode(StatusCodes.Status404NotFound,  "There was no albums found in this year range");
    }

    [HttpGet]
    [Route("GetAlbumsByGenre")]
    public async Task<IActionResult> GetAlbumsByGenre(Genres genre)
    {
        var albums = await _albumService.GetAlbumsByGenre(genre);
        return albums.Any() ? Ok(albums) : StatusCode(StatusCodes.Status404NotFound,  "There was no albums found in this genre");
    }

    [HttpGet]
    [Route("GetAlbumsByArtist")]
    public async Task<IActionResult> GetAlbumsByArtist(string artist)
    {
        var albums = await _albumService.GetAlbumsByArtist(artist);
        return albums.Any() ? Ok(albums) : StatusCode(StatusCodes.Status404NotFound,  "There was no albums by this artist");
    }

    [HttpPost]
    [Route("CreateAlbum")]
    public async Task<IActionResult> CreateAlbumsAsync(Album album)
    {
        var result = await _albumService.CreateAlbum(album);
        return Ok(result);
    }
}