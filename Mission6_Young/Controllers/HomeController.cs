using System.Diagnostics;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Young.Models;

namespace Mission6_Young.Controllers;

public class HomeController : Controller
{
    private MovieContext _context;
    
    public HomeController(MovieContext temp) //Constructor
    {
        _context = temp;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult GetToKnowJoel()
    {
        return View();
    }
    [HttpGet]
    public IActionResult EnterMovies()
    {
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View(new Movie());
    }
    
    [HttpPost]
    public IActionResult EnterMovies (Movie response)
    {
        _context.Movies.Add(response); // Add record to the database
        
        try // Error Handling
        {
            _context.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            var innerException = ex.InnerException?.Message;
            Console.WriteLine("Error saving to database: " + innerException);
            throw; // Re-throw to see full error details in logs
        }
        
        return RedirectToAction("EnterMovies");
    }

    public IActionResult ViewMovies() // Returns the database in a table format, passing in movies variable as a list
    {
        var movies = _context.Movies
            .Include(x => x.Category)
            .ToList();
        
        return View(movies);
    }

    [HttpGet]
    public IActionResult EditMovie(int movieId)
    {
        var movieToEdit = _context.Movies
            .Single(x => x.MovieId == movieId);
        
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View("EnterMovies", movieToEdit);
    }

    [HttpPost]
    public IActionResult EditMovie(Movie updatedMovie)
    {
        _context.Update(updatedMovie);
        _context.SaveChanges();
        
        return RedirectToAction("ViewMovies");
    }

    [HttpGet]
    public IActionResult DeleteMovie(int movieId)
    {
        var movieToDelete = _context.Movies
            .Single(x => x.MovieId == movieId);
        
        return View(movieToDelete);
    }

    [HttpPost]
    public IActionResult DeleteMovie(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        
        return RedirectToAction("ViewMovies");
    }
    
}