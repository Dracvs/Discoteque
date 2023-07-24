namespace Discoteque.Data.Models;

public class Artist : BaseEntity<int>
{
    /// <summary>
    /// The Name of the Artist
    /// </summary>
    /// <value></value>
    public string Name { get; set; } = "";
    public string Label { get; set; } = "";
    public bool IsOnTour{ get; set; }
}