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
    public class MovieCastsServiceAsync : IMovieCastsServiceAsync
    {
        private IMovieCastsRepositoryAsync _repository;

        public MovieCastsServiceAsync(IMovieCastsRepositoryAsync repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<MovieCasts>> GetCastsByMovieIdAsync(int id)
        {
            return await _repository.GetCastsByMovieIdAsync(id);
        }
    }
}
