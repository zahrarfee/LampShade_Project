using System;
using System.Collections.Generic;
using _0_Framework.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastracture.EFCore;

namespace InventoryManagement.Application
{
    public class InventoryApplication:IInventoryApplication
    {

        private readonly IInventoryRepository _inventoryRepository;
        private readonly IAuthHelper _authHelper;
            public InventoryApplication(IInventoryRepository inventoryRepository, IAuthHelper authHelper)
            {
                _inventoryRepository = inventoryRepository;
                _authHelper = authHelper;
            }

        public OperationResult Create(CreateInventory command)
        {
            var operationResult=new OperationResult();
            if (_inventoryRepository.Exist(x => x.ProductId == command.ProductId))
                return operationResult.Failed(ApplicationMessage.DublicatedRecord);
            var inventory=new Inventory(command.ProductId,command.UnitPrice);
            _inventoryRepository.Create(inventory);
            _inventoryRepository.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult Edit(EditInventory command)
        {
            var operationResult = new OperationResult();
            var inventory = _inventoryRepository.Get(command.Id);
            if (inventory==null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            if (_inventoryRepository.Exist(x => x.ProductId == command.ProductId && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessage.DublicatedRecord);
                inventory.Edit(command.ProductId, command.UnitPrice);
          
            _inventoryRepository.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult Increase(IncreaseInventory command)
        {
            var operationResult = new OperationResult();
            var inventory = _inventoryRepository.Get(command.InventoryId);
            if (inventory == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            const long operatorId = 1;

            inventory.Increase(command.Count, operatorId, command.Description);
            _inventoryRepository.SaveChange();
            return operationResult.Succeced();


        }

        public OperationResult Reduce(List<ReduceInventory> command)
        {
            var operatorId = _authHelper.CurrentAccountId();
            var operationResult = new OperationResult();
            foreach (var item in command)
            {
                var inventory = _inventoryRepository.GetBy(item.ProductId);
                inventory.Reduce(item.Count,operatorId,item.Description,item.OrderId);

            }
            
            _inventoryRepository.SaveChange();
            return operationResult.Succeced();
        }

        public OperationResult Reduce(ReduceInventory command)
        {
            var operationResult = new OperationResult();
            var inventory = _inventoryRepository.Get(command.InventoryId);
            if (inventory == null)
                return operationResult.Failed(ApplicationMessage.RecordNotFound);
            var operatorId = _authHelper.CurrentAccountId();

            inventory.Reduce(command.Count, operatorId, command.Description,0);
            _inventoryRepository.SaveChange();
            return operationResult.Succeced();
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            return _inventoryRepository.Search(searchModel);
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryRepository.GetDetails(id);
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
           return _inventoryRepository.GetOperationLog(inventoryId);
        }
    }
}
