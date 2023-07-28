using System.Collections;
using Discoteque.Data.Models;

namespace Discoteque.Data.Dto;

public class SongMessage : BaseMessage
{
    public List<Song> Songs { get; set; } = new();
}