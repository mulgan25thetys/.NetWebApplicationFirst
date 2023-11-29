using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Web.Data.Infrastructures
{
    public class Repository<T> : IRepository<T> where T : class
    {
        readonly WebContext AppContext;
        readonly DbSet<T> DbSet;
        public Repository(IDataBaseFactory dataBaseFactory)
        {
            this.AppContext = dataBaseFactory.Context;
            this.DbSet = this.AppContext.Set<T>();
        }
        public void Add(T item)
        {
            DbSet.Add(item);
        }

        public T Delete(T item)
        {
            DbSet.Remove(item);
            return item;
        }

        public T DeleteByExpression(Expression<Func<T, bool>> expression)
        {
            T item = DbSet.Where(expression).SingleOrDefault();
            DbSet.Remove(item);
            return item;
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public ICollection<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
            {
                return DbSet.AsEnumerable().ToList();
            }
            return DbSet.Where(expression).AsEnumerable().ToList();
        }

        public T GetByExpression(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression).FirstOrDefault();
        }

        public T Update(T item)
        {
            DbSet.Update(item);
            return item;
        }
    }
}
