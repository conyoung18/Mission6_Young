using System.ComponentModel.DataAnnotations;

namespace Mission6_Young.Models;

// enum class to set static values for the dropdown
public enum Rating
{
    G,
    PG,
    [Display(Name = "PG-13")]
    PG13,
    R
}

public class Movie
{
    [Key]
    [Required]
    public int MovieID { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public string Director { get; set; }
    [Required]
    public Rating Rating { get; set; }

    public bool Edited { get; set; } = false;
    public string? Lent_To { get; set; } // ? = null is acceptable
    [MaxLength(25)]
    public string? Notes { get; set; }
    
}