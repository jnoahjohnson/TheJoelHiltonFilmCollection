using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheJoelHiltonFilmCollection.Models;

namespace TheJoelHiltonFilmCollection.Controllers
{
    // Controller for film CRUD operations
    public class MoviesController : Controller
    {
        // Getting the context

        private readonly FilmDbContext _context;

        public MoviesController(FilmDbContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // Validate antiforgery helps with forgery adn overposting
        // Binding is a way to basiclally implement a honeypot
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,Category,Title,Year,Director,Rating,Edited,LentTo,Notes")] Movie movie)
        {
            // Check if the model state is valid
            if (ModelState.IsValid)
            {
                // Add then then save the context
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            // Check and see if the id that was passed in is there
            if (id == null)
            {
                return NotFound();
            }

            // Find movie and see if it exists
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // Again this is pretectign from forgery or overposting
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Category,Title,Year,Director,Rating,Edited,LentTo,Notes")] Movie movie)
        {
            // Passing in id and the movie, check if it is the same
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            // If the movie is valid
            if (ModelState.IsValid)
            {
                // Try catch to make sure that an error doesn't crash the app
                // The context handles the update and then saves
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            // Make sure that there is an id
            if (id == null)
            {
                return NotFound();
            }

            // Check and find movie and then passs it intot he delete page.
            // This is not deleting the movie, just making the page
            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Finding the movie and then removing that movie and saving the database
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Helper function to see if movie exists based on an id
        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
