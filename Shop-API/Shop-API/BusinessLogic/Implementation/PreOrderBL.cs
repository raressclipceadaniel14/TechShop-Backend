using Shop_API.BusinessLogic.Interface;
using Shop_API.Models.PreOrder;
using Shop_API.Models.Product;
using Shop_API.Repository.Interface;

namespace Shop_API.BusinessLogic.Implementation
{
    public class PreOrderBL : IPreOrderBL
    {
        private readonly IPreOrderRepository _preOrderRepository;

        public PreOrderBL(IPreOrderRepository preOrderRepository)
        {
            this._preOrderRepository = preOrderRepository;
        }

        public async Task<List<ProductModel>> GetPreorderByUserAsync(int userId)
        {
            var products = await _preOrderRepository.GetPreorderByUserAsync(userId);
            return products;
        }

        public async Task SavePreOrder(PreOrderSaveModel preOrderSaveModel)
        {
            await _preOrderRepository.SavePreOrder(preOrderSaveModel);
        }

        public async Task DeletePreOrder(int userId)
        {
            await _preOrderRepository.DeletePreOrder(userId);
        }

        public async Task DeleteFromCart(PreOrderSaveModel preOrderSaveModel)
        {
            await _preOrderRepository.DeleteFromCart(preOrderSaveModel);
        }
    }
}
