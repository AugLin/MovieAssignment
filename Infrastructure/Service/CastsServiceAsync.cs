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
    public class CastsServiceAsync : ICastsServiceAsync
    {
        private ICastsRepositoryAsync _repository;

        public CastsServiceAsync(ICastsRepositoryAsync repository)
        {
            _repository = repository;
        }
        public async Task<Casts> GetCastByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
