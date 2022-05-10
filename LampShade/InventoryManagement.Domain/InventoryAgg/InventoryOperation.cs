using System;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class InventoryOperation
    {
        public long Id { get; private set; }
        public bool Operation { get; private set; }  //وارد شده یا خارج
        public long Count { get; private set; }   //چه تعداد وارد یا خارج شده
        public long OperatorId { get; private set; }  //چه کسی وارد یا خارج کرده
        public DateTime OperationDate { get; private set; }
        public long CurrentCount { get; private set; }//در تاریخی که این عملیات انجام شده موجودی انبار چقدر بوده
        public string Description { get; private set; }
        public long OrderId { get; private set; }//شماره سفارش مشتری
        public long InventoryId { get; private set; } // این عملیات مربوط به کدوم انبار بوده
        public Inventory Inventory { get; private set; }

        public InventoryOperation(bool operation, long count, long operatorId, long currentCount, string description, long orderId, long inventoryId)
        {
            Operation = operation;
            Count = count;
            OperatorId = operatorId;
            CurrentCount = currentCount;
            Description = description;
            OrderId = orderId;
            InventoryId = inventoryId;
            OperationDate=DateTime.Now;
        }
    }
}