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
    public class MovieGenresServiceAsync : IMovieGenresServiceAsync
    {
        private readonly IMovieGenresRepositoryAsync _repository;

        public MovieGenresServiceAsync(IMovieGenresRepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MovieGenres>> GetGenreMoviesAsync(int id)
        {
            return await _repository.GetGenreMoviesAsync(id);
        }
    }
}
