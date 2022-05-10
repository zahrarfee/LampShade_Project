using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Domain;
using InventoryManagement.Application.Contract.Inventory;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepository:IRepository<long,Inventory>
    {


        Inventory GetBy(long productId);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        EditInventory GetDetails(long id);
        List<InventoryOperationViewModel> GetOperationLog(long inventoryId);
    }
}
