using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Service
{
    public interface IMoviesService
    {
        IEnumerable<Movies> GetMostPopularMovies();
        IEnumerable<Movies> GetMoviesByGenre(int id);

        Movies GetByID(int id);
    }
}
