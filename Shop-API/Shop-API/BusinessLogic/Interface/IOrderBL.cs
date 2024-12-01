using Shop_API.Models.Order;

namespace Shop_API.BusinessLogic.Interface
{
    public interface IOrderBL
    {
        Task PlaceOrder(AddOrderModel placeOrderModel);
    }
}
