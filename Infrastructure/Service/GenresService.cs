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
    public class GenresService : IGenresService
    {
        private IGenresRepository _genresRepository;

        public GenresService(IGenresRepository repo)
        {
            _genresRepository = repo;
        }

        public int AddGenre(Genres genre)
        {
            return _genresRepository.Insert(genre);
        }

        public int DeleteGenre(int id)
        {
            return _genresRepository.Delete(id);
        }

        public IEnumerable<Genres> GetAllGenre()
        {
            return _genresRepository.GetAll();
        }

        public Genres GetGenreById(int id)
        {
            return _genresRepository.GetById(id);
        }

        public int UpdateGenre(Genres genre, int id)
        {
            if (genre.Id == id)
            {
                return _genresRepository.Update(genre);
            }
            return 0;
        }
    }
}
