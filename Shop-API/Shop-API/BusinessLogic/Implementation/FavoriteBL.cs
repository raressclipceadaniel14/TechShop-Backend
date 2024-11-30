using Shop_API.BusinessLogic.Interface;
using Shop_API.Models.Favorite;
using Shop_API.Models.Product;
using Shop_API.Repository.Implementation;
using Shop_API.Repository.Interface;

namespace Shop_API.BusinessLogic.Implementation
{
    public class FavoriteBL : IFavoriteBL
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteBL(IFavoriteRepository favoriteRepository)
        {
            this._favoriteRepository = favoriteRepository;
        }
        public async Task<List<ProductModel>> GetFavoriteByUserAsync(int userId)
        {
            var products = await _favoriteRepository.GetFavoriteByUserAsync(userId);
            return products;
        }

        public async Task SaveFavorite(FavoriteModel model)
        {
            await _favoriteRepository.SaveFavorite(model);
        }
    }
}
