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
        public ActionResult Index()
        {
            return View();
        }

        // GET: Articles
        public ActionResult edit()
        {
            return View();
        }

        public string GetArticlesInfos()
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
            var result = JsonConvert.SerializeObject(res);
            return result;
        }

        [HttpPost]
        public string Save()
        {
            var saveData = Request.Params["saveData"];
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