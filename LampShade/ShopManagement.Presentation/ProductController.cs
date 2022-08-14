using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contracts.Product;

namespace ShopManagement.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductQuery _product;

        public ProductController(IProductQuery product)
        {
            _product = product;
        }

        [HttpGet]
        public List<ProductQueryModel> GetLatestArrivals()
        {
            return _product.GetLatestArrivals();
        }
    }
}
