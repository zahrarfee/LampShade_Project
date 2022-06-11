using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0_Framework.Application;
using _01_LampshadeQuery.Contracts.Article;
using _01_LampshadeQuery.Contracts.ArticleCategory;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace _01_LampshadeQuery.Query
{
    public class ArticleCategoryQuery:IArticleCategoryQuery
    {
        private readonly BlogContext _blogContext;

        public ArticleCategoryQuery(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public List<ArticleCategoryQueryModel> GetCategories()
        {
            return _blogContext.ArticleCategories
                .Include(x=>x.Articles)
                .Select(x => new ArticleCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                Slug = x.Slug,
                ArticlesCount = x.Articles.Count

            }).ToList();
        }

        public ArticleCategoryQueryModel GetArticleCategory(string slug)
        {
            var category= _blogContext.ArticleCategories
                .Include(x=>x.Articles)
                .Select(x => new ArticleCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Picture = x.Picture,
                    ShowOrder = x.ShowOrder,
                    Description = x.Description.Substring(0,Math.Min(x.Description.Length,50)),


                    Slug = x.Slug,
                    MetaDescription = x.MetaDescription,
                    Keywords = x.Keywords,
                    ArticlesCount = x.Articles.Count,
                    CanonicalAddress = x.CanonicalAddress,
                    Articles=MapArticles(x.Articles)
                })
                .FirstOrDefault(x => x.Slug == slug);
            if (!string.IsNullOrWhiteSpace(category.Keywords))
                category.KeywordsList = category.Keywords.Split(",").ToList();

            return category;

        }

        private static List<ArticleQueryModel> MapArticles(List<Article> Articles)
        {
            return Articles.Select(x => new ArticleQueryModel
            {
                Id = x.Id,
                Title = x.Title,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Picture = x.Picture,
                PublishDate = x.PublishDate.ToFarsi(),
                Slug = x.Slug,
                ShortDescription = x.ShortDescription
            }).ToList();
        }
    }
}
