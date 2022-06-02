using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0_Framework.Application;
using _0_Framework.Infrastracture;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class ArticleRepository:RepositoryBase<long,Article> , IArticleRepository
    {
        private readonly BlogContext _context;

        public ArticleRepository(BlogContext context): base(context)
        {
            _context = context;
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            var query = _context.Articles
                .Include(x => x.Category)
                .Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToFarsi(),
                ShortDescription = x.ShortDescription,
                Category = x.Category.Name,
                PublishDate = x.PublishDate.ToFarsi(),
                CategoryId = x.CategoryId

            });
            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            if (searchModel.CategoryId>0)
                query = query.Where(x => x.CategoryId==searchModel.CategoryId);

            //if (searchModel.Categories=null)
            //    query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }

        public EditArticle GetDetails(long id)
        {
            return _context.Articles
                .Include(x => x.Category)
                .Select(x => new EditArticle()
                {
                    Id = x.Id,
                    Title = x.Title,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Description = x.Description,
                    ShortDescription = x.ShortDescription,
                    CategoryId = x.CategoryId,
                    PublishDate = x.PublishDate.ToFarsi(),

                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription,
                    CanonicalAddress = x.CanonicalAddress,
                    Slug = x.Slug


                }).FirstOrDefault(x=>x.Id==id);
        }

        public void Delete(long id)
        {
            var query = _context.Articles.FirstOrDefault(x => x.Id == id);
            _context.Articles.Remove(query);
        }
    }
}
