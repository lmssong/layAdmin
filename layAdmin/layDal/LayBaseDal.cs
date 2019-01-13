using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace layDal
{
    public class LayBaseDal<T> where T:class,new()
    {

        /// <summary>
        /// db上下文对象
        /// </summary>
        private DbContext _dbContext = LayDbContext.Create();

        public void Add(T t)
        {
            _dbContext.Set<T>().Add(t);
        }

        public IQueryable<T> GetInfos(Expression<Func<T,bool>> where)
        {
            return _dbContext.Set<T>().Where(where);
        }

        /// <summary>
        /// 保存更改的数据
        /// </summary>
        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;
        }
    }
}
