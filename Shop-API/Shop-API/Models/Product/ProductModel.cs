namespace Shop_API.Models.Product
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
        public int SubCategoryId { get; set; }
        public int ProviderId { get; set; }
        public string? Picture { get; set; }
    }
}
