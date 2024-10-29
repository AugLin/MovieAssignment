using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using GenFu.ValueGenerators.Music;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Repositories
{
    public class MoviesRepositoryAsync : BaseRepositoryAsync<Movies>, IMoviesRepositoryAsync
    {
        private readonly MovieDbConnection _connection;
        public MoviesRepositoryAsync(MovieDbConnection c) : base(c)
        {
            _connection = c;
        }

        public async Task<int> GetCountAllAsync(int id)
        {
            return await _connection.Movies
                         .Join(
                             _connection.MovieGenres,
                             movie => movie.Id,
                             movieGenre => movieGenre.MovieId,
                             (movie, movieGenre) => new { movie, movieGenre }
                         )
                         .Where(mg => mg.movieGenre.GenreId == id)
                         .CountAsync();
        }

        public async Task<IEnumerable<Movies>> GetMoviesByGenreAsync(int id, int page, int pageSize)
        {

            var movies = await _connection.Movies
                 .Join(
                     _connection.MovieGenres,
                     movie => movie.Id,
                     movieGenre => movieGenre.MovieId,
                     (movie, movieGenre) => new { movie, movieGenre }
                 )
                 .Where(mg => mg.movieGenre.GenreId == id)
                 .Select(mg => mg.movie)
                 .OrderByDescending(m => m.Revenue)
                 .Skip((page - 1) * pageSize)
                 .Take(pageSize)
                 .Distinct()
                 .ToListAsync();

            return movies;
        }

        public async Task<IEnumerable<Movies>> GetTopRevenueMoviesAsync()
        {
            return await _connection.Movies.OrderByDescending(x => x.Revenue).Take(24).ToListAsync();
        }

    }
}
