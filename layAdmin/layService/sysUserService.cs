using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using layModel;
using layDal;

namespace layService
{
    public class sysUserService : LayBaseService<sys_user>,IsysUserService
    {
        private IsysUserDal sysUserDal = DalFactory.GetInstance<sysUserDal, IsysUserDal>();

        public override void SetDal()
        {
            this.dal = sysUserDal;
        }

        public override void SetKID(sys_user t)
        {
            t.KID = DateTime.Now.ToLongTimeString();
        }
    }
}
