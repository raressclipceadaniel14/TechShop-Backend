using Shop_API.Models.Order;

namespace Shop_API.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<int> AddOrder(AddOrderModel order);
        Task<OrderModel> GetLastOrderByUser(int userId);
        Task SaveProductsInOrder(List<int> productsId, int orderId);
    }
}
