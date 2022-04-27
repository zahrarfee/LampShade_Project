using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountManagement.Application.Contracts.CollegueDiscount
{
    public class CollegueDiscountViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public int DiscountRate { get; set; }
        public string Product { get; set; }
        public string CreationDate { get; set; }
        public bool IsRemoved { get; set; }
    }

}
