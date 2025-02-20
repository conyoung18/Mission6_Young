using Microsoft.EntityFrameworkCore;

namespace Mission6_Young.Models;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options) // Constructor inheriting other options
    {
    }
    
    public DbSet<Movie> Movies { get; set; } // Movie of type DbSet setting the table in the database called movies
    public DbSet<Category> Categories { get; set; } // Category of type DbSet setting the table called Categories

    protected override void OnModelCreating(ModelBuilder modelBuilder) // Seed data
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Miscellaneous" },
            new Category { CategoryId = 2, CategoryName = "Drama" },
            new Category { CategoryId = 3, CategoryName = "Television" },
            new Category { CategoryId = 4, CategoryName = "Horror/Suspense" },
            new Category { CategoryId = 5, CategoryName = "Comedy" },
            new Category { CategoryId = 6, CategoryName = "Family" },
            new Category { CategoryId = 7, CategoryName = "Action/Adventure" },
            new Category { CategoryId = 8, CategoryName = "VHS" }
            );
    }
}