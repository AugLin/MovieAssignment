using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenresRepositoryAsync : BaseRepositoryAsync<Genres>, IGenresRepositoryAsync
    {

        public GenresRepositoryAsync(MovieDbConnection connection) : base(connection)
        {
        }


    }
}
