using System.ComponentModel.DataAnnotations.Schema;

namespace Discoteque.Data.Models;

public class Tour : BaseEntity<int>
{
    public string Name { get; set;} = "";
    public string City {get;set;} = "";
    public DateTime TourDate { get; set;} = DateTime.Now;
    public bool IsSoldOut { get; set;} = false;
    
    [ForeignKey("Artist")]
    public int ArtistId { get; set;}
    public virtual Artist? Artist { get; set;}
}