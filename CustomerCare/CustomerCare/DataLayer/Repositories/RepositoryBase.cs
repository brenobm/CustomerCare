using CustomerCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CustomerCare.DataLayer.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : ModelBase
    {
        private CustomerCareContext _context;

        public RepositoryBase(CustomerCareContext context)
        {
            _context = context;
        }

        public void Delete(T entity)
        {
            _context.Connection.Delete(entity);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public T Get(int id)
        {
            return _context.Connection.Table<T>().FirstOrDefault(t => t.Id == id);
        }

        public void Insert(T entity)
        {
            try
            {
                _context.Connection.Insert(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void InsertAll(IEnumerable<T> entities)
        {
            _context.Connection.InsertAll(entities);
        }

        public IList<T> List(Expression<Func<T, bool>> query)
        {
            return _context.Connection.Table<T>().Where(query).ToList();
        }

        public IList<T> List(IList<Expression<Func<T, bool>>> query)
        {
            try
            {
                var queryFilter = _context.Connection.Table<T>();

                foreach (var q in query)
                {
                    queryFilter = queryFilter.Where(q);
                }

                return queryFilter.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IList<T> ListAll()
        {
            return _context.Connection.Table<T>().ToList();
        }

        public void Update(T entity)
        {
            _context.Connection.Update(entity);
        }

        public void UpdateAll(IEnumerable<T> entities)
        {
            _context.Connection.UpdateAll(entities);
        }
    }
}
