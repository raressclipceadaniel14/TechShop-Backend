using Shop_API.Models.Order;
using Shop_API.Models.Product;

namespace Shop_API.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<int> AddOrder(AddOrderModel order);
        Task<OrderModel> GetLastOrderByUser(int userId);
        Task<List<GetOrdersModel>> GetOrders();
        Task SaveProductsInOrder(List<int> productsId, int orderId);
        Task<List<ProductModel>> GetProductsByOrderId(int orderId);
    }
}
