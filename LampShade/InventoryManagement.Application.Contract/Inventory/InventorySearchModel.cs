using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Contract.Inventory
{
     public class InventorySearchModel
    {
        public long ProductId { get; set; }
        public bool InStock { get; set; }
    }
}
