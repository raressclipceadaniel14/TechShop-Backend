using Shop_API.Models.Product;

namespace Shop_API.Repository.Interface
{
    public interface IPreOrderRepository
    {
        Task<List<ProductModel>> GetPreorderByUserAsync(int userId);
        Task SavePreOrder(int userId, int productId);
    }
}
