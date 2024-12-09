using Shop_API.Models.PreOrder;
using Shop_API.Models.Product;

namespace Shop_API.Repository.Interface
{
    public interface IPreOrderRepository
    {
        Task DeleteFromCart(PreOrderSaveModel preOrderSaveModel);
        Task DeletePreOrder(int userId);
        Task<List<ProductModel>> GetPreorderByUserAsync(int userId);
        Task SavePreOrder(PreOrderSaveModel preOrderSaveModel);
    }
}
