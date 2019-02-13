using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using layModel;
using layService;
using Newtonsoft.Json;

namespace layAdmin.Controllers
{
    public class ArticlesController : Controller
    {
        private IArticlesService _articlesService = ServiceFactory.GetService<ArticlesService, IArticlesService>();
       
        // GET: Articles
        public ActionResult index()
        {
            return View();
        }

        // GET: Articles
        [ValidateInput(false)]
        public ActionResult edit()
        {
            return View();
        }

        public string GetArticlesInfos()
        {
            var msg = "";
            var result = "";
            try
            {
                var list = _articlesService.GetInfos(p => p.KID != null);
                List<articles> articles = list.ToList<articles>();
                TableResult res = new TableResult
                {
                    code = 0,
                    msg = "",
                    count = articles.Count,
                    data = articles.ToArray()

                };
                result = JsonConvert.SerializeObject(res);
                LogHelper.WriteLogs(result);
            }
            catch (Exception ex) {

                LogHelper.WriteLogs(ex.Message);
                msg = ex.Message;
            }
            return string.IsNullOrEmpty(msg) ? result : "查询数据发生异常，请查看日志";
        }

        [HttpPost]
        [ValidateInput(false)]
        public string Save()
        {
            string saveData = Request.Params["saveData"];
            saveData = saveData.Replace("\r\n", "<br/>").Replace("\\n", "<br/>").Replace(" ", "&nbsp;");
            articles entity = JsonConvert.DeserializeObject<articles>(saveData);
            bool isSave = _articlesService.Add(entity);
            return isSave ? "1" : "0";
        }

    }

    public class TableResult
    {
        public int code { get; set; }
        public string msg { get; set; }
        public int count { get; set; }
        public Array data { get; set; }
    }
}