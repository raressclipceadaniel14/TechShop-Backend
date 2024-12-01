using Microsoft.AspNetCore.Mvc;
using Shop_API.BusinessLogic.Interface;
using Shop_API.Models.PreOrder;
using Shop_API.Models.Product;

namespace Shop_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PreOrderController : ControllerBase
    {
        private readonly IPreOrderBL _preOrderBL;

        public PreOrderController(IPreOrderBL preOrderBL)
        {
            this._preOrderBL = preOrderBL;
        }

        [HttpGet("get-preorder-by-user")]
        public async Task<IEnumerable<ProductModel>> GetPreorderByUserAsync(int userId)
        {
            var products = await _preOrderBL.GetPreorderByUserAsync(userId);
            return products;
        }

        [HttpPost("save-preorder")]
        public async Task SavePreOrder([FromBody] PreOrderSaveModel preOrderSaveModel)
        {
            await _preOrderBL.SavePreOrder(preOrderSaveModel);
        }

        [HttpPost("delete-preorder")]
        public async Task DeletePreOrder([FromBody] int userId)
        {
            await _preOrderBL.DeletePreOrder(userId);
        }
    }
}
