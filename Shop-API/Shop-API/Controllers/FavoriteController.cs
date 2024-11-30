using Microsoft.AspNetCore.Mvc;
using Shop_API.BusinessLogic.Implementation;
using Shop_API.BusinessLogic.Interface;
using Shop_API.Models.Favorite;
using Shop_API.Models.Product;

namespace Shop_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteBL _favoriteBL;

        public FavoriteController(IFavoriteBL favoriteBL)
        {
            this._favoriteBL = favoriteBL;
        }

        [HttpGet("get-favorite-by-user")]
        public async Task<IEnumerable<ProductModel>> GetFavoriteByUserAsync([FromQuery]int userId)
        {
            var products = await _favoriteBL.GetFavoriteByUserAsync(userId);
            return products;
        }

        [HttpPost("save-favorite")]
        public async Task SaveFavorite([FromBody] FavoriteModel model)
        {
            await _favoriteBL.SaveFavorite(model);
        }
    }
}
