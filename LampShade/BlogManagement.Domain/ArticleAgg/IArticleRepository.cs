using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Application;
using _0_Framework.Domain;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository:IRepository<long,Article>
    {
        List<ArticleViewModel> Search(ArticleSearchModel searchModel);
        EditArticle GetDetails(long id);
        void Delete(long id);

    }
}
