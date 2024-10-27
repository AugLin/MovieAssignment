using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Repositories
{
    public interface IMoviesRepository : IRepository<Movies>
    {
        IEnumerable<Movies> GetTopRevenueMovies();
        IEnumerable<Movies> GetMoviesByGenre(int id);

    }
}
