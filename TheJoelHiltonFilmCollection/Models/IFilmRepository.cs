using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheJoelHiltonFilmCollection.Models
{
    // Interface for the repository
    public interface IFilmRepository
    {
        IQueryable<Movie> Movies { get; }
    }
}
