using System.ComponentModel.DataAnnotations;

namespace Mission6_Young.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    
}