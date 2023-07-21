using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Discoteque.Data.Models;

public class BaseEntity<TId> 
where TId : struct
{
    [Key]
    public TId Id {get; set;}
}