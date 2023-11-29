using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Data.Infrastructures
{
    public class DataBaseFactory : Disposable, IDataBaseFactory
    {
        readonly WebContext context;
        public WebContext Context => context;

        public DataBaseFactory() { 
            context = new WebContext();
        }
        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
