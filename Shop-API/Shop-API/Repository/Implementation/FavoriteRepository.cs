using api.Repositories.Implementations;
using Dapper;
using Shop_API.Models.Favorite;
using Shop_API.Models.Product;
using Shop_API.Repository.Interface;
using System.Data;
using System.Reflection;

namespace Shop_API.Repository.Implementation
{
    public class FavoriteRepository : BaseRepository, IFavoriteRepository
    {
        private const string GetFavoriteByUserSP = "Favorite_GetFavoriteByUser";
        private const string SaveFavoriteSP = "Favorite_SaveFavorite";

        public FavoriteRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<ProductModel>> GetFavoriteByUserAsync(int userId)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                return (await connection.QueryAsync<ProductModel>(GetFavoriteByUserSP,
                    param: new
                    {
                        userId
                    },
                    commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task SaveFavorite(FavoriteModel model)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                await connection.ExecuteAsync(SaveFavoriteSP,
                param: new
                {
                    model.UserId,
                    model.ProductId
                },
                commandType: CommandType.StoredProcedure);
            }
        }
    }
}
