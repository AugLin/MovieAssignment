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
    public class MovieGenresRepositoryAsync : BaseRepositoryAsync<MovieGenres>, IMovieGenresRepositoryAsync
    {
        private readonly MovieDbConnection _connection;
        public MovieGenresRepositoryAsync(MovieDbConnection c) : base(c)
        {
            _connection = c;
        }

        public async Task<IEnumerable<MovieGenres>> GetGenreMoviesAsync(int id)
        {
            return await _connection.MovieGenres.Include(x => x.GenreId == id).ToListAsync();
        }
    }
}
