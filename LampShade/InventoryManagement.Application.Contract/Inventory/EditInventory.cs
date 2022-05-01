using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Contract.Inventory
{
    public class EditInventory : CreateInventory
    {
        public long Id { get; set; }
    }
}
