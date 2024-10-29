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
    public class UsersServiceAsync : IUsersServiceAsync
    {
        private readonly IUsersRepositoryAsync _usersRepository;

        public UsersServiceAsync(IUsersRepositoryAsync repository)
        {
            _usersRepository = repository;
        }

        public async Task<int> AddUsersAsync(Users user)
        {
            return await _usersRepository.InsertAsync(user);
        }

        public async Task<Users>GetUsersByEmailAsync(string email)
        {
            return await _usersRepository.GetUserByEmailAsync(email);
        }

        public async Task<int> ValidateUsersAsync(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
