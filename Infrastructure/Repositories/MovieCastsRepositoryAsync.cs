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
    public class MovieCastsRepositoryAsync : BaseRepositoryAsync<MovieCasts>, IMovieCastsRepositoryAsync
    {
        private readonly MovieDbConnection _connection;

        public MovieCastsRepositoryAsync(MovieDbConnection c) : base(c)
        {
            _connection = c;
        }


        public async Task<IEnumerable<MovieCasts>> GetCastsByMovieIdAsync(int id)
        {
            return await _connection.MovieCasts.Where(mc => mc.MovieId == id).ToListAsync();
        }
    }
}
