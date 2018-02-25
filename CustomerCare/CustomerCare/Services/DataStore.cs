using CustomerCare.DataLayer;
using CustomerCare.DataLayer.Repositories;
using CustomerCare.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Xamarin.Forms;

namespace CustomerCare.Services
{
    public abstract class DataStore<T> : IDataStore<T>
        where T: ModelBase
    {
        protected IRepositoryBase<T> _repository;

        protected UnitOfWork _uow;

        public DataStore()
        {
            _uow = DependencyService.Get<UnitOfWork>();
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public T Get(int id)
        {
            return _repository.Get(id);
        }

        public void Insert(T entity)
        {
            _repository.Insert(entity);
        }

        public void InsertAll(IEnumerable<T> entities)
        {
            _repository.InsertAll(entities);
        }

        public IList<T> List(Expression<Func<T, bool>> query)
        {
            return _repository.List(query);
        }

        public IList<T> List(IList<Expression<Func<T, bool>>> query)
        {
            return _repository.List(query);
        }

        public IList<T> ListAll()
        {
            return _repository.ListAll();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public void UpdateAll(IEnumerable<T> entities)
        {
            _repository.UpdateAll(entities);
        }
    }
}
