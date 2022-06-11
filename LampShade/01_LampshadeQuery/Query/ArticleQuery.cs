using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0_Framework.Application;
using _01_LampshadeQuery.Contracts.Article;
using BlogManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace _01_LampshadeQuery.Query
{
    public class ArticleQuery:IArticleQuery
    {
        private readonly BlogContext _blogContext;

        public ArticleQuery(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public List<ArticleQueryModel> LatestArticles()
        {
          return  _blogContext.Articles.Include(x => x.Category).Where(x=>x.PublishDate<=DateTime.Now).Select(x => new ArticleQueryModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Picture = x.Picture,
                    PublishDate = x.PublishDate.ToFarsi(),
                   
                    ShortDescription = x.ShortDescription,  
                    Slug = x.Slug
                   
                })
                .OrderByDescending(x => x.Id).Take(3).ToList();
        }

        public ArticleQueryModel GetArticleDetails(string slug)
        {
            var article= _blogContext.Articles
                .Include(x=>x.Category)
                .Where(x => x.PublishDate <= DateTime.Now)
                .Select(x => new ArticleQueryModel
            {
                Id = x.Id,
                Title = x.Title,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Picture = x.Picture,
                PublishDate = x.PublishDate.ToFarsi(),
                
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                //CategoryId = x.CategoryId,
                Category = x.Category.Name,
                CategorySlug = x.Category.Slug,
                Slug = x.Slug,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                CanonicalAddress = x.CanonicalAddress
            }).FirstOrDefault(x => x.Slug == slug);
            if (!string.IsNullOrWhiteSpace(article.Keywords))
                article.KeywordsList = article.Keywords.Split(",").ToList();

            return article;
        }
    }
}
