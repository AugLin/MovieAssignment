using ApplicationCore.Contract.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly MovieDbConnection _connection;
        public BaseRepositoryAsync(MovieDbConnection connection)
        {
            this._connection = connection;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _connection.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _connection.Set<T>().Remove(entity);
                return await _connection.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _connection.Set<T>().ToListAsync(); ;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _connection.Set<T>().FindAsync(id);
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return await _connection.Set<T>().Where(filter).CountAsync();
            }
            return await _connection.Set<T>().CountAsync();
        }

        public async Task<int> InsertAsync(T entity)
        {
            await _connection.Set<T>().AddAsync(entity);
            return await _connection.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _connection.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await _connection.SaveChangesAsync();
        }
    }
}
