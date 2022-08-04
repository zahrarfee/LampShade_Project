using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.Application.Contracts.Order
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }
        public int PaymentMethod { get; set; }
        public int SendMethod { get; set; }
       
        public double TotalAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double PayAmount { get; set; }

        public Cart()
        {
            Items=new List<CartItem>();
        }

        public void Add(CartItem cartItem)
        {
            Items.Add(cartItem);
            TotalAmount += cartItem.TotalItemPrice;
            DiscountAmount += cartItem.DiscountAmount;
            PayAmount += cartItem.ItemPayAmount;
        }

        public void SetPaymentMethod(int payMethodId)
        {
            PaymentMethod = payMethodId;
        }

        public void SetSendMethod(int sendMethodId)
        {
            SendMethod = sendMethodId;
        }
     
 

    }
}
