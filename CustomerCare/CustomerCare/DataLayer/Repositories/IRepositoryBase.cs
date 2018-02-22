using CustomerCare.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CustomerCare.DataLayer.Repositories
{
    public interface IRepositoryBase<T>
        where T : ModelBase
    {
        void Insert(T entity);
        void InsertAll(IEnumerable<T> entities);
        void Delete(T entity);
        void Update(T entity);
        void UpdateAll(IEnumerable<T> entities);
        T Get(int id);
        IList<T> ListAll();
        IList<T> List(Expression<Func<T, bool>> query);
        IList<T> List(IList<Expression<Func<T, bool>>> query);
    }
}
