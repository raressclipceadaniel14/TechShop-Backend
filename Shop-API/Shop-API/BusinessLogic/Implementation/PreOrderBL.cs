using Shop_API.BusinessLogic.Interface;
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

        public async Task SavePreOrder(int userId, int productId)
        {
            await _preOrderRepository.SavePreOrder(userId, productId);
        }
    }
}
