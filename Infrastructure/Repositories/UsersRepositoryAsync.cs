using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UsersRepositoryAsync : BaseRepositoryAsync<Users>, IUsersRepositoryAsync
    {
        private readonly MovieDbConnection _connection;
        public UsersRepositoryAsync(MovieDbConnection c) : base(c)
        {
            _connection = c;
        }

        public async Task<Users> GetUserByEmailAsync(string email)
        {
            return await _connection.Users.FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}
