using layModel;
using layService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace layAdmin.Controllers
{
    public class UsersController : Controller
    {
        private IsysUserService _sysUserService = ServiceFactory.GetService<sysUserService, IsysUserService>();

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public string GetUserInfos()
        {
            var list = _sysUserService.GetInfos(p => p.KID != null);
            List<sys_user> users = list.ToList<sys_user>();
            TableResult res = new TableResult
            {
                code = 0,
                msg = "",
                count = users.Count,
                data = users.ToArray()

            };
            var result = JsonConvert.SerializeObject(res);
            return result;
        }
    }
}