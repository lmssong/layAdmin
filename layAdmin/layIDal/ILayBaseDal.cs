using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace layDal
{
    public interface ILayBaseDal<T> where T:class,new()
    {
        void Add(T t);

        IQueryable<T> GetInfos(Expression<Func<T, bool>> where);

        bool Save();
    }
}
