using System.Collections;
using Discoteque.Data.Models;

namespace Discoteque.Data.Dto;

public class ArtistMessage : BaseMessage<Artist>
{
    public List<Artist> Artists{ get; set; } = new();
}