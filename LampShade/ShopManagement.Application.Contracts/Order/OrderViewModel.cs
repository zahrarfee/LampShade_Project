using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.Application.Contracts.Order
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        public long AccountId { get;set; }
        public string AccountFullName { get; set; }
        public int PaymentMethodId { get;set; }
        public string PaymentMethod { get; set; }
        public int SendMethodId { get; set; }
        public string SendMethod { get;set; }

        public double TotalAmount { get;set; }
        public double DiscountAmount { get;set; }
        public double PayAmount { get;set; }
        public bool IsPayed { get;set; }
        public bool IsCanceled { get;set; }
        public string IssueTrackingNo { get;set; }
        public long RefId { get;set; }//Tracking number after purchase
        public string CreationDate { get; set; }
        
    }
}
