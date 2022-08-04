using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Domain;

namespace ShopManagement.Domain.OrderAgg
{
    public class Order:EntityBase
    {
        public long AccountId { get; private set; }
        public int PaymentMethod { get; private set; }
        public int SendMethod { get; private set; }
       
        public double TotalAmount { get; private set; }
        public double DiscountAmount { get; private set; }
        public double PayAmount { get; private set; }
        public bool IsPayed { get; private set; }
        public bool IsCanceled { get; private set; }
        public string IssueTrackingNo { get; private set; }
        public long RefId { get; private set; }//Tracking number after purchase
        public List<OrderItem> Items { get; private set; }

        public Order(long accountId,int paymentMethod ,int sendMethod,double totalAmount,double discountAmount, double payAmount)
        {
            AccountId = accountId;
            PaymentMethod = paymentMethod;
            SendMethod = sendMethod;
            TotalAmount = totalAmount;
            DiscountAmount = discountAmount;
            PayAmount = payAmount;
            
            //Items = items;
            IsPayed = false;
            IsCanceled = false;
            RefId = 0;
            Items=new List<OrderItem>();
        }

        public void Cancel()
        {
            IsCanceled = true; 
        }

        public void AddItem(OrderItem item)
        {
            this.Items.Add(item);
        }
        public void PaymentSucceeded(long refId)
        {
            IsPayed = true;
            if (refId != 0)
                RefId = refId;

        }

        public void SetIssueTrackingNo(string number)
        {
            IssueTrackingNo = number;
        }
    }
}
