using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0_Framework.Application;
using _0_Framework.Infrastracture;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class ArticleCategoryRepository:RepositoryBase<long,ArticleCategory> , IArticleCategoryRepository
    {
        private readonly BlogContext _blogContext;

        public ArticleCategoryRepository(BlogContext blogContext) : base(blogContext)
        {
            _blogContext = blogContext;
        }

        public EditArticleCategory GetDetails(long id)
        {
            return _blogContext.ArticleCategories.Select(x => new EditArticleCategory
                {
                    Id = x.Id,
                    Name = x.Name,
                    PictureTitle = x.PictureTitle,
                    PictureAlt = x.PictureAlt,
                    Description = x.Description,
                    ShowOrder = x.ShowOrder,
                    Slug = x.Slug,
                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription,
                    CanonicalAddress = x.CanonicalAddress,
                    

                })
                .FirstOrDefault(x => x.Id == id);
        }
        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            var query = _blogContext.ArticleCategories
                .Include(x=>x.Articles)
                .Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description.Substring(0,Math.Min(x.Description.Length,50)) + " ...",
                ShowOrder = x.ShowOrder,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToFarsi(),
                CountArticle = x.Articles.Count

            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            }

            query = query.OrderByDescending(x => x.ShowOrder);
            return query.ToList();
        }

        public string GetCategorySlugBy(long id)
        {
            return _blogContext.ArticleCategories.Select(x=>new {x.Id,x.Slug}).FirstOrDefault(x => x.Id == id).Slug;
        }

        public List<ArticleCategoryViewModel> GetCategories()
        {
            return _blogContext.ArticleCategories.Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public void Delete(long id)
        {
            var category=_blogContext.ArticleCategories.FirstOrDefault(x => x.Id == id);
            _blogContext.Remove(category);
        }
    }
}
