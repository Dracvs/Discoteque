using System.Net;
using Discoteque.Business.IServices;
using Discoteque.Data;
using Discoteque.Data.Models;
using Discoteque.Data.Dto;

namespace Discoteque.Business.Services;

public class SongService : ISongService
{
    private readonly IUnitOfWork _unitOfWork;

    public SongService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<SongMessage> CreateSong(Song newSong)
    {
        try
        {         
            var album = await _unitOfWork.AlbumRepository.FindAsync(newSong.AlbumId);
            if (album == null)
            {
                return BuildResponse(HttpStatusCode.NotFound, BaseMessageStatus.ALBUM_NOT_FOUND);
            }

            await _unitOfWork.SongRepository.AddAsync(newSong);
            await _unitOfWork.SaveAsync();
        }
        catch (Exception ex)
        {
            return BuildResponse(HttpStatusCode.InternalServerError, ex.Message);
        } 

        return BuildResponse(HttpStatusCode.OK, BaseMessageStatus.OK_200, new(){newSong});       
    }

    public async Task<Song> GetById(int id)
    {
        return await _unitOfWork.SongRepository.FindAsync(id);
    }

    public async Task<IEnumerable<Song>> GetSongsAsync()
    {
        return await _unitOfWork.SongRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Song>> GetSongsByAlbum(int AlbumId)
    {
        return await _unitOfWork.SongRepository.GetAllAsync(x => x.AlbumId == AlbumId);
    }

    public async Task<IEnumerable<Song>> GetSongsByYear(int year)
    {
        return await _unitOfWork.SongRepository.GetAllAsync(x => x.Album.Year == year, includeProperties: new Album().GetType().Name);
    }

    public async Task<Song> UpdateSong(Song song)
    {
        await _unitOfWork.SongRepository.Update(song);
        await _unitOfWork.SaveAsync();
        return song;
    }

    private static SongMessage BuildResponse(HttpStatusCode statusCode, string message)
    {
        return new SongMessage{
            Message = message,
            TotalElements = 0,
            StatusCode = statusCode                
        }; 
    }
    
    private static SongMessage BuildResponse(HttpStatusCode statusCode, string message, List<Song> songs)
    {
        return new SongMessage{
            Message = message,
            TotalElements = songs.Count,
            StatusCode = statusCode,
            Songs = songs                
        }; 
    }
}