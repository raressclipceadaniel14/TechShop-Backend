using Shop_API.Models.PreOrder;
using Shop_API.Models.Product;

namespace Shop_API.BusinessLogic.Interface
{
    public interface IPreOrderBL
    {
        Task DeleteFromCart(PreOrderSaveModel preOrderSaveModel);
        Task DeletePreOrder(int userId);
        Task<List<ProductModel>> GetPreorderByUserAsync(int userId);
        Task SavePreOrder(PreOrderSaveModel preOrderSaveModel);
    }
}
