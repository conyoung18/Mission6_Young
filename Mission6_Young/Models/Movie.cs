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
    public int? CategoryID { get; set; }
    public Category? Category { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public int Year { get; set; }
    public string? Director { get; set; }
    public Rating? Rating { get; set; }
    [Required]
    public bool Edited { get; set; } = false;
    public string? Lent_To { get; set; }
    [Required]
    public bool CopiedToPlex { get; set; } = false;
    [MaxLength(25)]
    public string? Notes { get; set; }
    
}