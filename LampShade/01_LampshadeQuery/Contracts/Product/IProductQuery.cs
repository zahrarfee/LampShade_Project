using System;
using System.Collections.Generic;
using System.Text;

namespace _01_LampshadeQuery.Contracts.Product
{
     public interface IProductQuery
     {
         //ProductQueryModel GetDetails(string slug);
         List<ProductQueryModel> GetLatestArrivals();
         List<ProductQueryModel> Search(string value);
         ProductQueryModel GetProductWithPictures(string slug);
    }
}
