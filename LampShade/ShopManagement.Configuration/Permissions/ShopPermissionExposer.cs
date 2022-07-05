using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Infrastracture;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Configuration.Permissions
{
    public class ShopPermissionExposer:IPermissionExposer
    {
       

        

        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Product" , new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.ListProducts, "ListProducts"),
                        new PermissionDto(ShopPermissions.SearchProducts, "SearchProducts"),
                        new PermissionDto(ShopPermissions.CreateProducts, "CreateProducts"),
                        new PermissionDto(ShopPermissions.EditProducts, "EditProducts")

                    }

                },
                {
                    "ProductCategory" , new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.ListProductCategories, "ListProductCategories"),
                        new PermissionDto(ShopPermissions.SearchProductCategories, "SearchProductCategories"),
                        new PermissionDto(ShopPermissions.CreateProductCategories, "CreateProductCategories"),
                        new PermissionDto(ShopPermissions.EditProductCategories, "EditProductCategories")
                    }
                }

            };
        }
    }
}
