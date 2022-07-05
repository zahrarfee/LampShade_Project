using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Infrastracture;

namespace InventoryManagement.Infrastracture.Configuration.Permissions
{
    public class InventoryPermissionExposer:IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Inventory" , new List<PermissionDto>
                    {
                        new PermissionDto(InventoryPermissions.ListInventories, "ListInventories"),
                        new PermissionDto(InventoryPermissions.SearchInventories, "SearchInventories"),
                        new PermissionDto(InventoryPermissions.CreateInventories, "CreateInventories"),
                        new PermissionDto(InventoryPermissions.EditInventories, "EditInventories"),
                        new PermissionDto(InventoryPermissions.Increase, "Increase"),
                        new PermissionDto(InventoryPermissions.Reduce, "Reduce"),
                        new PermissionDto(InventoryPermissions.OperationLog, "OperationLog")

                    }

                }
               

            };
        }
    }
}
