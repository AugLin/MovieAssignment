using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Repositories
{
    public interface IMoviesRepositoryAsync : IRepositoryAsync<Movies>
    {
        Task<IEnumerable<Movies>> GetTopRevenueMoviesAsync();
        Task<IEnumerable<Movies>> GetMoviesByGenreAsync(int id);

    }
}
