using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using layDal;
using System.Linq.Expressions;

namespace layService
{
    public abstract class LayBaseService<T> where T:class,new()
    {
        public ILayBaseDal<T> dal { get; set; }

        public abstract void SetDal();

        public abstract void SetKID(T t);

        public LayBaseService()
        {
            SetDal();
        }

        public bool Add(T t)
        {
            this.SetKID(t);
            dal.Add(t);
            return dal.Save();
        }

        public IQueryable<T> GetInfos(Expression<Func<T,bool>> where)
        {
            return dal.GetInfos(where);
        }
    }
}
