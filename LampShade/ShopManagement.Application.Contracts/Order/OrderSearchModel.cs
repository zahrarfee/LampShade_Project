using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.Application.Contracts.Order
{
    public class OrderSearchModel
    {
        public long AccountId { get; set; }
        public bool IsCanceled { get; set; }
    }
}
