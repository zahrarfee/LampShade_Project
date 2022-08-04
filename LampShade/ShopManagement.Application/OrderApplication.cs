
using _0_Framework.Application;
using InventoryManagement.Application.Contract.Inventory;
using Microsoft.Extensions.Configuration;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Application
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly IOrderRepository _orderRepository;
        private readonly IConfiguration _configuration;
        private readonly IInventoryApplication _inventoryApplication;

        public OrderApplication(IOrderRepository orderRepository, IAuthHelper authHelper, IConfiguration configuration, IInventoryApplication inventoryApplication)
        {
            _orderRepository = orderRepository;
            _authHelper = authHelper;
            _configuration = configuration;
            _inventoryApplication = inventoryApplication;
        }

        public long PlaceOrder(Cart cart)
        {
            var currentAccountId = _authHelper.CurrentAccountId();
            var order = new Order(currentAccountId,cart.PaymentMethod,cart.SendMethod, cart.TotalAmount, cart.DiscountAmount, cart.PayAmount);
            foreach (var cartItem in cart.Items)
            {
                var orderitem = new OrderItem(cartItem.Id, cartItem.Count, cartItem.UnitPrice, cartItem.DiscountRate);
                order.AddItem(orderitem);

            }

            _orderRepository.Create(order);
            _orderRepository.SaveChange();
            return order.Id;


        }

        public string PaymentSucceeded(long orderId, long refId)
        {
            var order = _orderRepository.Get(orderId);
            order.PaymentSucceeded(refId);
            //var symbol = _configuration.GetValue<string>("Symbol");
            var symbol = _configuration["Symbol"];
            var issueTrackingNo = CodeGenerator.Generate(symbol);
            order.SetIssueTrackingNo(issueTrackingNo);

            //Reduce from Inventory
            
            _orderRepository.SaveChange();
            return issueTrackingNo;

        }

        public double GetAmountBy(long id)
        {
            return _orderRepository.GetAmountBy(id);
        }


    }
}
