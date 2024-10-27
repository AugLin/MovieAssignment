using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Service;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class MovieGenresService : IMovieGenresService
    {
        private readonly IMovieGenresRepository _repository;

        public MovieGenresService(IMovieGenresRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<MovieGenres> GetGenreMovies(int id)
        {
            return _repository.GetGenreMovies(id);
        }
    }
}
