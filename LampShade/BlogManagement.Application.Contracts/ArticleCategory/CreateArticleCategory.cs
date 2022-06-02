using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using _0_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public class CreateArticleCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get;set; }

        [MaxFileSize(3 * 1024 * 1024 ,ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get;set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get; set; }
      
        public string Description { get;set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public int ShowOrder { get;set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get;set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Keywords { get;set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get;set; }
        public string CanonicalAddress { get;set; }
        }

}
