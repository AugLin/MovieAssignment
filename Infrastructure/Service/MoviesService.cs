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
    public class MoviesService : IMoviesService
    {
        private IMoviesRepository _repository;

        public MoviesService(IMoviesRepository repository)
        {
            _repository = repository;
        }

        public Movies GetByID(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Movies> GetMostPopularMovies()
        {
            return _repository.GetTopRevenueMovies();
        }

        public IEnumerable<Movies> GetMoviesByGenre(int id)
        {
            return _repository.GetMoviesByGenre(id);
        }
    }
}
