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
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository repository)
        {
            _usersRepository = repository;
        }

        public int AddUsers(Users user)
        {
            return _usersRepository.Insert(user);
        }

        public Users GetUsersByEmail(string email)
        {
            return _usersRepository.GetUserByEmail(email);
        }

        public int ValidateUsers(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
