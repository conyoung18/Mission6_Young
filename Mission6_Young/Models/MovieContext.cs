using Microsoft.EntityFrameworkCore;

namespace Mission6_Young.Models;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options) // Constructor inheriting other options
    {
    }
    
    public DbSet<Movie> Movies { get; set; } // Movie of type DbSet setting the database called movies
}