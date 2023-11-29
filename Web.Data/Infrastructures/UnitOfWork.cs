using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Data.Infrastructures
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        IDataBaseFactory dataBaseFactory;
        public UnitOfWork(IDataBaseFactory baseFactory) {
            this.dataBaseFactory = baseFactory;
        }
        public void Commit()
        {
            this.dataBaseFactory.Context.SaveChanges();
        }
        public void Dispose()
        {
            this.dataBaseFactory.Dispose();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(this.dataBaseFactory);
        }
    }
}
