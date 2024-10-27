using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieGenresRepository : BaseRepository<MovieGenres>, IMovieGenresRepository
    {
        private readonly MovieDbConnection _connection;
        public MovieGenresRepository(MovieDbConnection c) : base(c)
        {
            _connection = c;
        }

        public IEnumerable<MovieGenres> GetGenreMovies(int id)
        {
            return _connection.MovieGenres.Include(x => x.GenreId == id).ToList();
        }
    }
}
