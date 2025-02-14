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
    
    public IActionResult EnterMovies()
    {
        return View();
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
}