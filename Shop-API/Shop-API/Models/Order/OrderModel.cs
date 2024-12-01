namespace Shop_API.Models.Order
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime PlacementDate { get; set; }
        public int UserId { get; set; }
        public int OrderStatusId { get; set; }
        public int PaymentMethodId { get; set; }
    }
}
