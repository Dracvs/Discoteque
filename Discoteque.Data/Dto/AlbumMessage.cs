using System.Collections;
using Discoteque.Data.Models;

namespace Discoteque.Data.Dto;

public class AlbumMessage : BaseMessage
{
    public List<Album> Albums { get; set; } = new();
}