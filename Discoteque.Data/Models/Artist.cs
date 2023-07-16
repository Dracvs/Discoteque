using System.Runtime.CompilerServices;

namespace Discoteque.Data.Models;

public class Artist : BaseEntity<int>
{
    public string Name { get; set; } = "";
    public string Label { get; set; } = "";
    public bool IsOnTour{ get; set; }
}