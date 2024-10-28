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
    public class CastsRepository : BaseRepository<Casts>, ICastsRepository
    {
        public CastsRepository(MovieDbConnection c) : base(c)
        {
        }
    }
}
