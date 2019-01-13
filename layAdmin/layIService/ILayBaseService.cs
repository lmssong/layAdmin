using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace layService
{
    public interface ILayBaseService<T> where T:class,new()
    {
        bool Add(T t);

        IQueryable<T> GetInfos(Expression<Func<T,bool>> where);
    }
}
