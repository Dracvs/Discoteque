using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discoteque.Data.Models;

public  class Album : BaseEntity<int>
{
    /// <summary>
    /// Name of the Album
    /// </summary>
    public string Name { get; set; } = "";
    /// <summary>
    /// Year the albums was published
    /// </summary>
    public int Year { get; set; }
    
    /// <summary>
    /// The <see cref="Genres" /> the album belongs to 
    /// </summary>
    public Genres Genre { get; set; } = Genres.Unknown;
    
    /// <summary>
    /// The <see cref="Artist"/> id this Album belongs to
    /// </summary>
    /// <value></value>
    [ForeignKey("Id")]
    public int ArtistId { get; set; }

    /// <summary>
    /// The <see cref="Artist"/> Entity this album is refering to
    /// </summary> <summary>
    public virtual Artist? Artist { get; set; } 
}

/// <summary>
/// A collection of musical genres
/// </summary> <summary>
public enum Genres
{
    Rock,
    Metal,
    Salsa, 
    Merengue,
    Urban,
    Folk,
    Indie,
    Techno,
    Vallenato,
    Pop,
    Unknown
}