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
    public class GenresServiceAsync : IGenresServiceAsync
    {
        private IGenresRepositoryAsync _genresRepository;

        public GenresServiceAsync(IGenresRepositoryAsync repo)
        {
            _genresRepository = repo;
        }

        public async Task<int> AddGenreAsync(Genres genre)
        {
            return await _genresRepository.InsertAsync(genre);
        }

        public async Task<int> DeleteGenreAsync(int id)
        {
            return await _genresRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Genres>> GetAllGenreAsync()
        {
            return await _genresRepository.GetAllAsync();
        }

        public async Task<Genres> GetGenreByIdAsync(int id)
        {
            return await _genresRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateGenreAsync(Genres genre, int id)
        {
            return await _genresRepository.UpdateAsync(genre);
        }
    }
}
