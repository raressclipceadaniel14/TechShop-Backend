namespace Shop_API.Models.Product
{
    public class SearchResultDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public float Score { get; set; }
    }
}
