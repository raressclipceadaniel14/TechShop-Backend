namespace Shop_API.Models.Product
{
    public class GetProductModelRequest
    {
        public int CategoryId { get; set; }
        public int? SubcategoryId { get; set; }
    }
}
