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
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public OperationResult Create(CreateSlide command)
        {
            var operationResult=new OperationResult();
            if (_slideRepository.Exist(x => x.Picure == command.Picure))
                return operationResult.Failed(ApplicationMessage.DublicatedRecord);
            if (command == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            var slide=new Slide(command.Picure,command.PictureAlt,command.PicureTitle,command.Heading,command.Title,command.Text,command.BtnText,command.Link);
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
            slide.Edit(command.Picure, command.PictureAlt, command.PicureTitle, command.Heading, command.Title, command.Text, command.BtnText, command.Link);
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
