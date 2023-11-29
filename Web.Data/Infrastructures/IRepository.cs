using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Web.Data.Infrastructures
{
    public interface IRepository<T> where T : class
    {
        public ICollection<T> GetAll(Expression<Func<T, bool>> expression = null);
        public T Get(int id);
        public T GetByExpression(Expression<Func<T, bool>> expression);
        public void Add(T item);
        public T Update(T item);
        public T Delete(T item);
        public T DeleteByExpression(Expression<Func<T, bool>> expression);
    }
}
