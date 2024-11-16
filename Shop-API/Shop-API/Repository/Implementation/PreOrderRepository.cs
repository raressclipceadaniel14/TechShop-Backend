using api.Repositories.Implementations;
using Azure.Core;
using Dapper;
using Shop_API.Models.Product;
using Shop_API.Repository.Interface;
using System.Data;

namespace Shop_API.Repository.Implementation
{
    public class PreOrderRepository : BaseRepository, IPreOrderRepository
    {
        private const string GetPreorderByUserSP = "PreOrder_GetPreorderByUser";
        private const string SavePreorderSP = "PreOrder_SavePreOrder";

        public PreOrderRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<ProductModel>> GetPreorderByUserAsync(int userId)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                return (await connection.QueryAsync<ProductModel>(GetPreorderByUserSP,
                    param: new
                    {
                        userId
                    },
                    commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task SavePreOrder(int userId, int productId)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                await connection.ExecuteAsync(SavePreorderSP,
                param: new
                {
                    userId, 
                    productId
                },
                commandType: CommandType.StoredProcedure);
            }
        }
    }
}
