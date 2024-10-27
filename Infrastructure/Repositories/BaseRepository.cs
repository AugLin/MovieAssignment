using ApplicationCore.Contract.Repositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly MovieDbConnection _connection;
        public BaseRepository(MovieDbConnection c)
        {
            _connection = c;
        }

        public int Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _connection.Set<T>().Remove(entity);
                return _connection.SaveChanges();
            }
            return 0;
        }

        public IEnumerable<T> GetAll()
        {
            return _connection.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _connection.Set<T>().Find(id);
        }

        public int GetCount(Expression<Func<T, bool>> filter)
        {
            if (filter != null)
            {
                return _connection.Set<T>().Where(filter).Count();
            }
            return _connection.Set<T>().Count();
        }

        public int Insert(T entity)
        {
            _connection.Set<T>().Add(entity);
            return _connection.SaveChanges();
        }

        public int Update(T entity)
        {
            _connection.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _connection.SaveChanges();
        }
    }
}
