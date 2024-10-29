using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Service
{
    public interface IGenresServiceAsync
    {
        Task<int> AddGenreAsync(Genres genre);
        Task<int> UpdateGenreAsync(Genres genre, int id);
        Task<int> DeleteGenreAsync(int id);
        Task<IEnumerable<Genres>> GetAllGenreAsync();
        Task<Genres> GetGenreByIdAsync(int id);
    }
}
