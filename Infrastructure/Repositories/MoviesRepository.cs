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
    public class MoviesRepository : BaseRepository<Movies>, IMoviesRepository
    {
        private readonly MovieDbConnection _connection;
        public MoviesRepository(MovieDbConnection c) : base(c)
        {
            _connection = c;
        }

        public IEnumerable<Movies> GetMoviesByGenre(int id)
        {

            var movies = _connection.Movies
                         .Join(
                             _connection.MovieGenres,
                             movie => movie.Id,
                             movieGenre => movieGenre.MovieId,
                             (movie, movieGenre) => new { movie, movieGenre }
                         )
                         .Where(mg => mg.movieGenre.GenreId == id)
                         .Select(mg => mg.movie)
                         .OrderByDescending(m => m.Revenue)
                         .Take(24)
                         .Distinct()
                         .ToList();

            Console.WriteLine("Movies found: " + movies.Count); // Check if there are results
            return movies;
        }

        public IEnumerable<Movies> GetTopRevenueMovies()
        {
            return _connection.Movies.OrderByDescending(x => x.Revenue).Take(24).ToList();
        }

    }
}
