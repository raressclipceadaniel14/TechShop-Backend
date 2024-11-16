using Shop_API.Models.Product;

namespace Shop_API.Repository.Interface
{
    public interface IFavoriteRepository
    {
        Task<List<ProductModel>> GetFavoriteByUserAsync(int userId);
        Task SaveFavorite(int userId, int productId);
    }
}
