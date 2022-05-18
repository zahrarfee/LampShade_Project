using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Application
{
    public class SlideApplication:ISlideApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
        {
            _slideRepository = slideRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateSlide command)
        {
            var operationResult=new OperationResult();
            
            if (command == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
           
            var picture = _fileUploader.Upload(command.Picure ,"slides");
            var slide=new Slide(picture,command.PictureAlt,command.PicureTitle,command.Heading,command.Title,command.Text,command.BtnText,command.Link);
            _slideRepository.Create(slide);
            _slideRepository.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult Edit(EditSlide command)
        {
            var operationResult = new OperationResult();
            var slide = _slideRepository.Get(command.Id);
            if (slide == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            var picture = _fileUploader.Upload(command.Picure, "slides");
            slide.Edit(picture, command.PictureAlt, command.PicureTitle, command.Heading, command.Title, command.Text, command.BtnText, command.Link);
            _slideRepository.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult Remove(long id)
        {
            var operationResult = new OperationResult();
            var slide = _slideRepository.Get(id);
            if (slide == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            slide.Remove();
            _slideRepository.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult Restore(long id)
        {
            var operationResult = new OperationResult();
            var slide = _slideRepository.Get(id);
            if (slide == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            slide.Restore();
            _slideRepository.SaveChange();
            return operationResult.Succeced();
        }

        public List<SlideViewModel> GetList()
        {
          return _slideRepository.GetList();
        }

        public EditSlide GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }
    }
}
