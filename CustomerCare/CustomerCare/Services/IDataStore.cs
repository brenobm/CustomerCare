using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CustomerCare.Services
{
    public interface IDataStore<T>
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
