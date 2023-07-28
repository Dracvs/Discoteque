using System.Net;
using System;
using Discoteque.Business.IServices;
using Microsoft.AspNetCore.Mvc;
using Discoteque.Data.Models;
using Discoteque.Data.Dto;


namespace Discoteque.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SongController : ControllerBase
{
    private readonly ISongService _songService;

    public SongController(ISongService songService)
    {
        _songService = songService;
    }

    [HttpGet]
    [Route("GetSongById")]
    public async Task<IActionResult> GetById(int id)
    {
        var song = await _songService.GetById(id);
        return song != null ? Ok(song) :  StatusCode(StatusCodes.Status404NotFound, "No song was found");
    }

    [HttpGet]
    [Route("GetSongs")]
    public async Task<IActionResult> GetSongs()
    {   
        var songs = await _songService.GetSongsAsync();
        return songs.Any() ? Ok(songs) : StatusCode(StatusCodes.Status404NotFound, "No songs were found");
    }

    [HttpGet]
    [Route("GetSongsByAlbum")]
    public async Task<IActionResult> GetSongsByAlbum(int id)
    {
        var songs = await _songService.GetSongsByAlbum(id);
        return songs.Any()? Ok(songs) : StatusCode(StatusCodes.Status404NotFound, "No songs were found");
    }

    [HttpGet]
    [Route("GetSongsByYear")]
    public async Task<IActionResult> GetSongsByYear(int year)
    {
        var songs = await _songService.GetSongsByYear(year);
        return songs.Any()? Ok(songs) : StatusCode(StatusCodes.Status404NotFound, "No songs were found");
    }

    [HttpPost]
    [Route("CreateSong")]
    public async Task<IActionResult> CreateSong(Song song)
    {
        var newSong = await _songService.CreateSong(song);
        return newSong.StatusCode == HttpStatusCode.OK ? Ok(newSong) : StatusCode((int)newSong.StatusCode, newSong);
    }

    [HttpPatch]
    [Route("UpdateSong")]
    public async Task<IActionResult> UpdateSong(Song song)
    {
        var updateSong = await _songService.UpdateSong(song);
        return Ok(updateSong);
    }




}