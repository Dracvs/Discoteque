using System.Collections;
using Discoteque.Data.Models;

namespace Discoteque.Data.Dto;

public class ArtistMessage : BaseMessage
{
    public List<Artist> Artists{ get; set; } = new();
}