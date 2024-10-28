using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieCastsRepository : BaseRepository<MovieCasts>, IMovieCastsRepository
    {
        private readonly MovieDbConnection _connection;

        public MovieCastsRepository(MovieDbConnection c) : base(c)
        {
            _connection = c;
        }


        public IEnumerable<MovieCasts> GetCastsByMovieId(int id)
        {
            return _connection.MovieCasts.Where(mc => mc.MovieId == id).ToList();
        }
    }
}
