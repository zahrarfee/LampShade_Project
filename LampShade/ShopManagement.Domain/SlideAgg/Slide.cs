using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Domain;

namespace ShopManagement.Domain.SlideAgg
{
    public class Slide:EntityBase
    {
        public string Picure { get;private set; }
        public string PictureAlt { get; private set; }
        public string PicureTitle { get; private set; }
        public string Heading { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public string BtnText { get; private set; }
        public bool IsRemoved { get; private set; }

        public Slide(string picure, string pictureAlt, string picureTitle, string heading, string title, string text, string btnText)
        {
            Picure = picure;
            PictureAlt = pictureAlt;
            PicureTitle = picureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;
            IsRemoved = false;
        }
        public void Edit(string picure, string pictureAlt, string picureTitle, string heading, string title, string text, string btnText)
        {
            Picure = picure;
            PictureAlt = pictureAlt;
            PicureTitle = picureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;
            
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
