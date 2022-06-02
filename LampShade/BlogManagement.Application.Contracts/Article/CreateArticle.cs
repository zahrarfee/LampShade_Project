using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using _0_Framework.Application;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Http;

namespace BlogManagement.Application.Contracts.Article
{
    public class CreateArticle
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get;set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ShortDescription { get;set; }
        public string Description { get;set; }

        [MaxFileSize(3 * 1024 * 1024 ,ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get;set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get;set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get;set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PublishDate { get;set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get;set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Keywords { get;set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get;set; }
        public string CanonicalAddress { get; set; }
        [Range(1,long.MaxValue , ErrorMessage = ValidationMessages.IsRequired)]

        public long CategoryId { get;set; }
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }

    }
}
