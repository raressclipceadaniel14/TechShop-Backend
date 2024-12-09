using Shop_API.BusinessLogic.Interface;
using Shop_API.Models.Order;
using Shop_API.Models.Product;
using Shop_API.Repository.Interface;

namespace Shop_API.BusinessLogic.Implementation
{
    public class OrderBL : IOrderBL
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPreOrderRepository _preOrderRepository;
        private readonly IProductRepository _productRepository;

        public OrderBL(IOrderRepository orderRepository, IPreOrderRepository preOrderRepository, IProductRepository productRepository)
        {
            this._orderRepository = orderRepository;
            this._preOrderRepository = preOrderRepository;
            this._productRepository = productRepository;
        }

        public async Task PlaceOrder(AddOrderModel placeOrderModel)
        {
            var order = await _orderRepository.AddOrder(placeOrderModel);
            var cart = await _preOrderRepository.GetPreorderByUserAsync(placeOrderModel.UserId);
            List<int> productIdS = new List<int>();
            foreach (var product in cart) {
                productIdS.Add(product.Id);
                await _productRepository.ModifyStock(new StockUpdateModel
                {
                    ModifyBy = -1,
                    ProductId = product.Id,
                });
            }
            await _orderRepository.SaveProductsInOrder(productIdS, order);
            await _preOrderRepository.DeletePreOrder(placeOrderModel.UserId);
        }
    }
}
