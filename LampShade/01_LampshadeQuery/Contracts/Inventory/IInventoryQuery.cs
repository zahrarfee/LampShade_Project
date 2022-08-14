using System;
using System.Collections.Generic;
using System.Text;

namespace _01_LampshadeQuery.Contracts.Inventory
{
    public interface IInventoryQuery
    {
        StockStatus CheckStatus(IsInStock command);
    }
}
