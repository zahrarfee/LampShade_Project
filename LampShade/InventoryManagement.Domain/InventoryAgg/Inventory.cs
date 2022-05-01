using System.Collections.Generic;
using System.Linq;
using System.Text;
using _0_Framework.Domain;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory:EntityBase
    {
        public long ProductId { get; private set; }
        
        public double UnitPrice { get; private set; }
        public bool InStock  { get; private set; }
        public List<InventoryOperation> InventoryOperations { get; set; }

        public Inventory(long productId,  double unitPrice)
        {
            ProductId = productId;
           
            UnitPrice = unitPrice;
            InStock = false;//چون هنوز اپریشنی تعریف نکردیم مقدار فالس میگیره، در واقع فقط قفسه تعریف کردیم
            InventoryOperations=new List<InventoryOperation>();
        }
        public void Edit(long productId, double unitPrice)
        {
            ProductId = productId;

            UnitPrice = unitPrice;
            
           
        }

        public long CalculateCurrentInventoryStock()
        {
            var plus = InventoryOperations.Where(x => x.Operation == true).Sum(x => x.Count);
            var minus = InventoryOperations.Where(x => x.Operation == false).Sum(x => x.Count);
            return plus - minus;
        }

        public void Increase(long count,long operatorId , string description)
        {
            var currentcount = CalculateCurrentInventoryStock() + count;
            var operation =new InventoryOperation(true,count,operatorId,currentcount,description,0,Id);
            InventoryOperations.Add(operation);
            InStock = currentcount > 0;  //=if(currentcount>0) InStock==true; else InStock==false;

        }

        public void Reduce(long count,long operatorId, string description,long orderId)
        {
            var currentcount = CalculateCurrentInventoryStock() - count;
            var operation = new InventoryOperation(false, count, operatorId, currentcount, description,orderId,Id);
            InventoryOperations.Add(operation);
            InStock = currentcount > 0;  //=if(currentcount>0) InStock==true; else InStock==false;

        }
    }
}
