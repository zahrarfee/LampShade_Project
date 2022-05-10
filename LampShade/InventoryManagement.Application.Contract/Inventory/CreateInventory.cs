using ShopManagement.Application.Contracts.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using _0_Framework.Application;

namespace InventoryManagement.Application.Contract.Inventory
{
    public class CreateInventory
    {
        [Range(1,10000 , ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }


        [Range(1, Double.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public double UnitPrice { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }


}
