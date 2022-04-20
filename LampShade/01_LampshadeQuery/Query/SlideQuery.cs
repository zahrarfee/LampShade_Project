using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _01_LampshadeQuery.Contracts.Slide;
using ShopManagement.Infrastructure.EFCore;

namespace _01_LampshadeQuery.Query
{
    public class SlideQuery:ISlideQuery
    {
        private readonly ShopContext _shopContext;

        public SlideQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<SlideQueryModel> GetSlides()
        {
            return _shopContext.Slides.Where(x=>x.IsRemoved==false).Select(x => new SlideQueryModel
            {
                
                PicureTitle = x.PicureTitle,
                PictureAlt = x.PictureAlt,
                Picure = x.Picure,
                Link = x.Link,
                Heading = x.Heading,
                Text = x.Text,
                Title = x.Title,
                BtnText = x.BtnText
            }).ToList();
        }
    }
}
