using System.Collections;
using Discoteque.Data.Models;

namespace Discoteque.Data.Dto;

public class AlbumMessage : BaseMessage<Album>
{
    public List<Album> Albums { get; set; } = new();
}