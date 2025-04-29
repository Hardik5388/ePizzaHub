using ePizzaHub.Repositories.Interfaces;
using ePizzaHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Services.Implimentations
{
    public class Services<TEntity> : IServices<TEntity> where TEntity : class
    {
        private readonly IRepositories<TEntity> _repository;
        public Services(IRepositories<TEntity> repository)
        {
            _repository = repository;
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }
        public TEntity Get(object id)
        {
            return _repository.Get(id);
        }
        public void Add(TEntity entity)
        {
            _repository.Add(entity);
            _repository.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            _repository.Update(entity);
            _repository.SaveChanges();
        }
        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _repository.SaveChanges();
        }
        public void Delete(object id)
        {
           _repository.Delete(id);
        }
    }
    
}
