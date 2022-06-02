using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;

namespace BlogManagement.Application
{
    public class ArticleApplication:IArticleApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IArticleCategoryRepository _categoryRepository;
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository, IFileUploader fileUploader, IArticleCategoryRepository categoryRepository)
        {
            _articleRepository = articleRepository;
            _fileUploader = fileUploader;
            _categoryRepository = categoryRepository;
        }

        public OperationResult Create(CreateArticle command)
        {
            var operationResult = new  OperationResult();
            if (_articleRepository.Exist(x => x.Title == command.Title))
                return operationResult.Failed(ApplicationMessage.DublicatedRecord);
            var slug = command.Slug.Slugify();
            var categorySlug = _categoryRepository.GetCategorySlugBy(command.CategoryId);
            var path = $"{categorySlug}//{slug}";
            var picture = _fileUploader.Upload(command.Picture, path);
            var publishDate = command.PublishDate.ToGeorgianDateTime();
            var article=new Article(command.Title,command.ShortDescription,command.Description, picture, command.PictureAlt, command.PictureTitle, publishDate, slug, command.Keywords, command.MetaDescription, command.CanonicalAddress, command.CategoryId);
            _articleRepository.Create(article);
            _articleRepository.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult Edit(EditArticle command)
        {
            var operationResult = new OperationResult();
            var article = _articleRepository.Get(command.Id);
            if (article == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            if(_articleRepository.Exist(x=>x.Title==command.Title && x.Id!=command.Id))
                return operationResult.Failed(ApplicationMessage.DublicatedRecord);
            var slug = command.Slug.Slugify();
            var categorySlug = _categoryRepository.GetCategorySlugBy(command.CategoryId);
            var path = $"{categorySlug}//{slug}";
            var picture = _fileUploader.Upload(command.Picture, path);
            var publishDate = command.PublishDate.ToGeorgianDateTime();
            article.Edit(command.Title, command.ShortDescription, command.Description, picture, command.PictureAlt, command.PictureTitle, publishDate, slug, command.Keywords, command.MetaDescription, command.CanonicalAddress, command.CategoryId);
            _articleRepository.SaveChange();
            return operationResult.Succeced();
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            return _articleRepository.Search(searchModel);
        }

        public EditArticle GetDetails(long id)
        {
            return _articleRepository.GetDetails(id);
        }

        public OperationResult Delete(EditArticle command)
        {
            var operationResult = new OperationResult();
            var article = _articleRepository.Get(command.Id);
            if (article == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);

            _articleRepository.Delete(command.Id);
            _articleRepository.SaveChange();
            return operationResult.Succeced();
        }
    }
}
