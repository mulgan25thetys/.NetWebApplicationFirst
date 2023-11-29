using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Data.Infrastructures
{
    public interface IDataBaseFactory : IDisposable
    {
        WebContext Context { get; }
    }
}
