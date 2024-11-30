using Shop_API.Models.Favorite;
using Shop_API.Models.Product;

namespace Shop_API.BusinessLogic.Interface
{
    public interface IFavoriteBL
    {
        Task<List<ProductModel>> GetFavoriteByUserAsync(int userId);
        Task SaveFavorite(FavoriteModel model);
    }
}
