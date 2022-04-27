using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Domain;

namespace DiscountManagement.Domain.CollegueDiscountAgg
{
     public class CollegueDiscount:EntityBase
    {
        public long ProductId { get; private set; }
        public int DiscountRate { get; private set; }
        public bool IsRemoved { get; private set; }

        public CollegueDiscount(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            IsRemoved = false;
        }
        public void Edit(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
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
