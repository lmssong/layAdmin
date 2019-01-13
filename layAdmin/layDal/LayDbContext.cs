using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using layModel;

namespace layDal
{
    public class LayDbContext
    {

        /// <summary>
        /// 创建唯一EF上下文对象，存在获取，反之创建
        /// </summary>
        /// <returns></returns>
        public static DbContext Create()
        {
            DbContext contextInstance = CallContext.GetData("dbContext") as DbContext;
            if(contextInstance == null)
            {
                contextInstance = new layadminEntities();
                CallContext.SetData("dbContext", contextInstance);
            }
            return contextInstance;
        }
    }
}
