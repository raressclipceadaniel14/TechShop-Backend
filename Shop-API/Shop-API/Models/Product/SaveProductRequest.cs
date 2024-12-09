namespace Shop_API.Models.Product
{
    public class SaveProductRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int SubCategoryId { get; set; }
        public int ProviderId { get; set; }
        public string? Picture { get; set; }
        public int Stock {  get; set; }
    } 
}
