using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheJoelHiltonFilmCollection.Models
{
    
    public class EFFilmRepository : IFilmRepository
    {
        // Context
        private FilmDbContext _context;

        // Cunstroctor
        public EFFilmRepository (FilmDbContext context)
        {
            _context = context;
        }

        public IQueryable<Movie> Movies => _context.Movies;
    }
}
