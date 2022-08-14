using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contracts.Product;
using InventoryManagement.Application.Contract;
using InventoryManagement.Application.Contract.Inventory;
using _01_LampshadeQuery.Contracts.Inventory;

namespace InventoryManagement.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryQuery _inventoryQuery;

        public InventoryController(IInventoryQuery inventoryQuery)
        {
            _inventoryQuery = inventoryQuery;
        }
        [HttpPost]
        public StockStatus CheckStatus(IsInStock isInStock)
        {
            return  _inventoryQuery.CheckStatus(isInStock);


        }
    }
}
