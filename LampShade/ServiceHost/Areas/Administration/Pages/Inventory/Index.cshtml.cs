using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Application.Contract.Inventory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    [Authorize(Roles = _0_Framework.Infrastracture.Roles.Administration)]
    public class IndexModel : PageModel
    {

        public SelectList Products;
        public InventorySearchModel SearchModel;
        public List<InventoryViewModel> Inventories;
        private readonly IProductApplication _productApplication;
        private readonly IInventoryApplication _inventoryApplication;

        public IndexModel(IInventoryApplication inventoryApplication, IProductApplication productApplication)
        {
            _inventoryApplication = inventoryApplication;
            _productApplication = productApplication;
        }

        public void OnGet(InventorySearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(),"Id" ,"Name");
            Inventories = _inventoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var pro = new CreateInventory();
            pro.Products = _productApplication.GetProducts();


            return Partial("Create", pro);
        }

        public JsonResult OnPostCreate(CreateInventory command)
        {
            var inventory = _inventoryApplication.Create(command);
            return new JsonResult(inventory);
        }

        public IActionResult OnGetEdit(long id)
        {
            var inventory = _inventoryApplication.GetDetails(id);
            inventory.Products = _productApplication.GetProducts(); 
            return Partial("Edit",inventory);
        }

        public JsonResult OnPostEdit(EditInventory command)
        {
            var inventory = _inventoryApplication.Edit(command);

            return new JsonResult(inventory);
        }

        public IActionResult OnGetIncrease(long id)
        {
            var command=new IncreaseInventory();
            command.InventoryId = id;
            return Partial("Increase",command);
        }

        public JsonResult OnPostIncrease(IncreaseInventory command)
        {
            var inventory=_inventoryApplication.Increase(command);
            return new JsonResult(inventory);
        }

        public IActionResult OnGetReduce(long id)
        {
            var command = new ReduceInventory();
            command.InventoryId = id;
            return Partial("Reduce", command);
        }

        public JsonResult OnPostReduce(ReduceInventory command)
        {
            var inventory = _inventoryApplication.Reduce(command);
            return new JsonResult(inventory);
        }

        public IActionResult OnGetLog(long id)
        {
            var log=_inventoryApplication.GetOperationLog(id);
            return Partial("OperationLog" , log);
        }


    }
}
