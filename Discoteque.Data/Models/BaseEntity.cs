using System.Globalization;
namespace Discoteque.Data.Models;

public class BaseEntity<TId> 
where TId : struct
{
    public TId Id {get; set;}
}