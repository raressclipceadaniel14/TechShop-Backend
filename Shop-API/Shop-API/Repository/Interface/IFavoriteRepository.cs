using Shop_API.Models.Favorite;
using Shop_API.Models.Product;

namespace Shop_API.Repository.Interface
{
    public interface IFavoriteRepository
    {
        Task<List<ProductModel>> GetFavoriteByUserAsync(int userId);
        Task SaveFavorite(FavoriteModel favoriteModel);
    }
}
