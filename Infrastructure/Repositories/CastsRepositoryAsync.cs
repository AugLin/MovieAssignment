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
    public class CastsRepositoryAsync : BaseRepositoryAsync<Casts>, ICastsRepositoryAsync
    {
        public CastsRepositoryAsync(MovieDbConnection c) : base(c)
        {
        }
    }
}
