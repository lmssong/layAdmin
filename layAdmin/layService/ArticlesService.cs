using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using layModel;
using layDal;

namespace layService
{
    public class ArticlesService : LayBaseService<articles>, IArticlesService
    {
        private IArticlesDal articlesDal = DalFactory.GetInstance<ArticlesDal, IArticlesDal>();

        public override void SetDal()
        {
            this.dal = articlesDal;
        }

        public override void SetKID(articles t)
        {
            t.KID = DateTime.Now.ToOADate().ToString();

        }
    }
}
