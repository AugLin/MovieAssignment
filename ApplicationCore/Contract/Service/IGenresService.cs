using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Service
{
    public interface IGenresService
    {
        int AddGenre(Genres genre);
        int UpdateGenre(Genres genre, int id);
        int DeleteGenre(int id);
        IEnumerable<Genres> GetAllGenre();
        Genres GetGenreById(int id);
    }
}
