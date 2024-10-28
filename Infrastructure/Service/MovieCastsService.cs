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
    public class MovieCastsService : IMovieCastsService
    {
        private IMovieCastsRepository _repository;

        public MovieCastsService(IMovieCastsRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<MovieCasts> GetCastsByMovieId(int id)
        {
            return _repository.GetCastsByMovieId(id);
        }

    }
}
