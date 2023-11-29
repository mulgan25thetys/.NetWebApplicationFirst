using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web.Data.Infrastructures;

namespace Web.Services
{
    public class Service<T> : IService<T> where T : class
    {
        readonly IUnitOfWork uow;
        readonly IRepository<T> repo;
        public Service(IUnitOfWork unitOf) { 
            uow = unitOf;
            repo = uow.GetRepository<T>();
        }
        public void Add(T item)
        {
             repo.Add(item);
        }

        public void Commit()
        {
            uow.Commit();
        }

        public T Delete(T item)
        {
            return repo.Delete(item);
        }

        public T DeleteByExpression(Expression<Func<T, bool>> expression)
        {
            return repo.GetByExpression(expression);
        }

        public T Get(int id)
        {
            return repo.Get(id);
        }

        public ICollection<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            if(expression == null)
            {
                return repo.GetAll();
            }
            return repo.GetAll(expression);
        }

        public T GetByExpression(Expression<Func<T, bool>> expression)
        {
            return repo.GetByExpression(expression);
        }

        public T Update(T item)
        {
            return repo.Update(item);
        }
    }
}
