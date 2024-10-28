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
    public class CastsService : ICastsService
    {
        private ICastsRepository _repository;

        public CastsService(ICastsRepository repository)
        {
            _repository = repository;
        }
        public Casts GetCastById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
