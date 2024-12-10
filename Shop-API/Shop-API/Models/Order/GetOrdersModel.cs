using Shop_API.Models.Product;

namespace Shop_API.Models.Order
{
    public class GetOrdersModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime PlacementDate { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentMethod { get; set; }
        public List<ProductModel>? Products { get; set; }
    }
}
