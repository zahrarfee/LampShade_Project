using System;
using System.Collections.Generic;
using System.Text;
using ShopManagement.Application.Contracts.Order;

namespace _01_LampshadeQuery.Contracts.Product
{
     public interface IProductQuery
     {
         //ProductQueryModel GetDetails(string slug);
         List<ProductQueryModel> GetLatestArrivals();
         List<ProductQueryModel> Search(string value);
         ProductQueryModel GetProductWithPictures(string slug);
         List<CartItem> GetInventoryStatus(List<CartItem> cartItems);
     }
}
