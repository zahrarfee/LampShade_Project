using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0_Framework.Application;
using _01_LampshadeQuery.Contracts.Article;
using _01_LampshadeQuery.Contracts.Comment;
using BlogManagement.Infrastructure.EFCore;
using CommentManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace _01_LampshadeQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _blogContext;
        private readonly CommentContext _commentContext;

        public ArticleQuery(BlogContext blogContext, CommentContext commentContext)
        {
            _blogContext = blogContext;
            _commentContext = commentContext;
        }

        public List<ArticleQueryModel> LatestArticles()
        {
            return _blogContext.Articles.Include(x => x.Category).Where(x => x.PublishDate <= DateTime.Now).Select(x =>
                    new ArticleQueryModel
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
            var article = _blogContext.Articles
                .Include(x => x.Category)
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
            var comments = _commentContext.Comments
                .Where(x => x.Type == CommentTypes.Article)
                .Where(x => x.OwnerRecordId == article.Id)
                .Where(x => x.IsConfirmed == true)
                
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Message = x.Message,
                    Name = x.Name,
                    Website = x.Website,
                    Email = x.Email,
                    ParentId = x.ParentId,
                    CreationDate = x.CreationDate.ToFarsi()
                }).OrderByDescending(x => x.Id).ToList();
            foreach (var item in comments)
            {
                if (item.ParentId > 0)
                    item.Parent = comments.FirstOrDefault(x => x.Id == item.ParentId)?.Name;
            }

            article.Comments = comments;    
            return article;
        }
    }
}