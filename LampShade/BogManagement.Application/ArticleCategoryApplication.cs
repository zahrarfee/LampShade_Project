using System;
using System.Collections.Generic;
using _0_Framework.Application;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;

namespace BlogManagement.Application
{
    public class ArticleCategoryApplication:IArticleCategoryApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IFileUploader fileUploader)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateArticleCategory command)
        {
            var operationResult = new OperationResult();
            if (_articleCategoryRepository.Exist(x => x.Name == command.Name))
            {
                return operationResult.Failed(ApplicationMessage.DublicatedRecord);
            }

            var slug = command.Slug.Slugify();
            var picture = _fileUploader.Upload(command.Picture, slug);
            var articleCategory = new ArticleCategory(command.Name, picture, command.PictureAlt,command.PictureTitle,command.Description, command.ShowOrder,
                slug, command.Keywords, command.MetaDescription, command.CanonicalAddress);
            _articleCategoryRepository.Create(articleCategory);

            _articleCategoryRepository.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult Edit(EditArticleCategory command)
        {
            var operationResult = new OperationResult();
            var articleCategory = _articleCategoryRepository.Get(command.Id);

            if (articleCategory == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            if (_articleCategoryRepository.Exist(x => x.Name == command.Name && x.Id!=command.Id))
                return operationResult.Failed(ApplicationMessage.DublicatedRecord);
           
            var slug = command.Slug.Slugify();
            var picture = _fileUploader.Upload(command.Picture, slug);
            articleCategory.Edit(command.Name, picture,command.PictureAlt,command.PictureTitle, command.Description, command.ShowOrder, slug, command.Keywords, command.MetaDescription, command.CanonicalAddress);
            

            _articleCategoryRepository.SaveChange();
            return operationResult.Succeced();

            }

            public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
            {
                return _articleCategoryRepository.Search(searchModel);
            }

            public EditArticleCategory GetDetails(long id)
            {
                return _articleCategoryRepository.GetDetails(id);

            }

            public List<ArticleCategoryViewModel> GetCategories()
            {
                return _articleCategoryRepository.GetCategories();
            }

            public OperationResult Delete(EditArticleCategory command)
            {
                var operationResult =new OperationResult();
                var category = _articleCategoryRepository.Get(command.Id);
                if(category==null)
                    return operationResult.Failed(ApplicationMessage.RecordNotFound);
                _articleCategoryRepository.Delete(command.Id);
                _articleCategoryRepository.SaveChange();
                return operationResult.Succeced();
            }

        //public string GetCategorySlugBy(long id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
