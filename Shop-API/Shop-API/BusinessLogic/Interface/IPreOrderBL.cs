using Shop_API.Models.Product;

namespace Shop_API.BusinessLogic.Interface
{
    public interface IPreOrderBL
    {
        Task<List<ProductModel>> GetPreorderByUserAsync(int userId);
        Task SavePreOrder(int userId, int productId);
    }
}
