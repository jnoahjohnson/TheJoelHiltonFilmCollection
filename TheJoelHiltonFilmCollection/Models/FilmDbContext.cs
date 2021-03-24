using Microsoft.EntityFrameworkCore;

namespace TheJoelHiltonFilmCollection.Models
{
    public class FilmDbContext : DbContext
    {
        public FilmDbContext (DbContextOptions<FilmDbContext> options) : base (options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
