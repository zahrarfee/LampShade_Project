using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using _0_Framework.Domain;
using _0_Framework.Infrastracture;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SlideRepository:RepositoryBase<long,Slide>,ISlideRepository
    {
        private readonly ShopContext _shopContext;

        public SlideRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }


        public List<SlideViewModel> GetList()
        {
           return _shopContext.Slides.Select(x => new SlideViewModel
            {
                Id = x.Id,
                Picure = x.Picure,
                Heading = x.Heading,
                Title = x.Title,
                IsRemoved = x.IsRemoved,
                CreationDate = x.CreationDate.ToString()
                

            }).OrderByDescending(x=>x.Id).ToList();
        }

        public EditSlide GetDetails(long id)
        {
            return _shopContext.Slides.Select(x => new EditSlide
            {
                Id = x.Id,
                Picure = x.Picure,
                PicureTitle = x.PicureTitle,
                PictureAlt = x.PictureAlt,
                Heading = x.Heading,
                Text = x.Text,
                Title = x.Title,
                BtnText = x.BtnText,
            }).FirstOrDefault(x => x.Id == id);
        }
    }
}
