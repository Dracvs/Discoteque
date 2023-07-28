using System.Collections;
using Discoteque.Data.Models;

namespace Discoteque.Data.Dto;

public class TourMessage : BaseMessage
{
    public List<Tour> Tours { get; set; } = new();
}