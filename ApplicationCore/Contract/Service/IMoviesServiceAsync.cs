﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Service
{
    public interface IMoviesServiceAsync
    {
        Task<IEnumerable<Movies>> GetMostPopularMoviesAsync();
        Task<IEnumerable<Movies>> GetMoviesByGenreAsync(int id, int page, int pageSize);
        Task<Movies> GetByIDAsync(int id);
        Task<int> GetCountAllAsync(int id);
    }
}
