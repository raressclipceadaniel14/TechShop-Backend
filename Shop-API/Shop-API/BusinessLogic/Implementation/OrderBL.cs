using Shop_API.BusinessLogic.Interface;
using Shop_API.Models.Order;
using Shop_API.Repository.Interface;

namespace Shop_API.BusinessLogic.Implementation
{
    public class OrderBL : IOrderBL
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPreOrderRepository _preOrderRepository;

        public OrderBL(IOrderRepository orderRepository, IPreOrderRepository preOrderRepository)
        {
            this._orderRepository = orderRepository;
            this._preOrderRepository = preOrderRepository;
        }

        public async Task PlaceOrder(AddOrderModel placeOrderModel)
        {
            var order = await _orderRepository.AddOrder(placeOrderModel);
            var cart = await _preOrderRepository.GetPreorderByUserAsync(placeOrderModel.UserId);
            List<int> productIdS = new List<int>();
            foreach (var product in cart) {
                productIdS.Add(product.Id);
            }
            await _orderRepository.SaveProductsInOrder(productIdS, order);
            await _preOrderRepository.DeletePreOrder(placeOrderModel.UserId);
        }
    }
}
