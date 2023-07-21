using Discoteque.Data.Models;
namespace Discoteque.Data.Services;

public interface IAlbumService
{
    /// <summary>
    /// Finds all albums in the EF DB
    /// </summary>
    /// <param name="areReferencesLoaded">Returns associated artists per album if true</param>
    /// <returns>A <see cref="List" /> of <see cref="Album"/> </returns>
    Task<IEnumerable<Album>> GetAlbumsAsync(bool areReferencesLoaded);
    
    /// <summary>
    /// Returns all albums published in the year.
    /// </summary>
    /// <param name="year">A gregorian year between 1900 and current year</param>
    /// <returns>A <see cref="List" /> of <see cref="Album"/> </returns>
    Task<IEnumerable<Album>> GetAlbumsByYear(int year);
    
    /// <summary>
    /// returns all albums released from initial to max year
    /// </summary>
    /// <param name="initialYear">The initial year, min value 1900</param>
    /// <param name="maxYear">the latest year, max value 2025</param>
    /// <returns>A <see cref="List" /> of <see cref="Album"/> </returns>
    Task<IEnumerable<Album>> GetAlbumsByYearRange(int initialYear, int maxYear);
    
    /// <summary>
    /// Returns all albums with the assigned genre
    /// </summary>
    /// <param name="genre">A genre from the <see cref="Genres"/> list</param>
    /// <returns>A <see cref="List" /> of <see cref="Album"/> </returns>
    Task<IEnumerable<Album>> GetAlbumsByGenre(Genres genre);
    
    /// <summary>
    /// A list of albums released by a <see cref="Artist.Name"/>
    /// </summary>
    /// <param name="artist">The name of the artist</param>
    /// <returns>A <see cref="List" /> of <see cref="Album"/> </returns>
    Task<IEnumerable<Album>> GetAlbumsByArtist(string artist);
    
    /// <summary>
    /// Get an album by its EF DB Identity
    /// </summary>
    /// <param name="id">The unique ID of the element</param>
    /// <returns>A <see cref="Album"/> </returns>
    Task<Album> GetById(int id);
    
    /// <summary>
    /// Creates a new <see cref="Album"/> entity in Database. 
    /// </summary>
    /// <param name="album">A new album entity</param>
    /// <returns>The created album with an Id assigned</returns>
    Task<Album> CreateAlbum(Album album);
    
    /// <summary>
    /// Updates the <see cref="Album"/> entity in EF DB
    /// </summary>
    /// <param name="album">The Album entity to update</param>
    /// <returns>The new album with updated fields if successful</returns>
    Task<Album> UpdateAlbum(Album album);
}