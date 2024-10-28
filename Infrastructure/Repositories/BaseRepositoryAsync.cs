using ApplicationCore.Contract.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly MovieDbConnection _connection;
        public BaseRepositoryAsync(MovieDbConnection connection) { 
            this._connection = connection;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var result = await _connection.Set<T>().FindAsync(id);
            if (result != null)
            {
                _connection.Set<T>().Remove(result);
            }
            return await _connection.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _connection.Set<T>().ToListAsync();
        }

        public async Task<int> InsertAsync(T entity)
        {
            await _connection.Set<T>().AddAsync(entity);
            return await _connection.SaveChangesAsync();
        }
    }
}
