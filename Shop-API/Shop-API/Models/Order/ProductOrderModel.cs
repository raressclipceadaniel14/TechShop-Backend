using Shop_API.Models.Product;

namespace Shop_API.Models.Order
{
    public class ProductOrderModel
    {
        public List<ProductModel> Products { get; set; }
        public int OrderId { get; set; }
    }
}
