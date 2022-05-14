using System;
using System.Collections.Generic;
using System.Text;

namespace _01_LampshadeQuery.Contracts.Product
{
     public interface IProductQuery
     {
         List<ProductQueryModel> GetLatestArrivals();
     }
}
