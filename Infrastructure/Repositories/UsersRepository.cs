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
    public class UsersRepository : BaseRepository<Users>, IUsersRepository
    {
        private readonly MovieDbConnection _connection;
        public UsersRepository(MovieDbConnection c) : base(c)
        {
            _connection = c;
        }

        public Users GetUserByEmail(string email)
        {
            return _connection.Users.FirstOrDefault(user => user.Email == email);
        }
    }
}
