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
    public class MoviesServiceAsync : IMoviesServiceAsync
    {
        private IMoviesRepositoryAsync _repository;

        public MoviesServiceAsync(IMoviesRepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task<Movies> GetByIDAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<int> GetCountAllAsync(int id)
        {
            return await _repository.GetCountAllAsync(id);
        }

        public async Task<IEnumerable<Movies>> GetMostPopularMoviesAsync()
        {
            return await _repository.GetTopRevenueMoviesAsync();
        }

        public async Task<IEnumerable<Movies>> GetMoviesByGenreAsync(int id, int page, int pageSize)
        {
            return await _repository.GetMoviesByGenreAsync(id, page, pageSize);
        }
    }
}
