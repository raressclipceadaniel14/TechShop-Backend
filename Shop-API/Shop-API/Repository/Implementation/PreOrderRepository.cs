using api.Repositories.Implementations;
using Azure.Core;
using Dapper;
using Shop_API.BusinessLogic.Implementation;
using Shop_API.Models.PreOrder;
using Shop_API.Models.Product;
using Shop_API.Repository.Interface;
using System.Data;

namespace Shop_API.Repository.Implementation
{
    public class PreOrderRepository : BaseRepository, IPreOrderRepository
    {
        private const string GetPreorderByUserSP = "PreOrder_GetPreorderByUser";
        private const string SavePreorderSP = "PreOrder_SavePreOrder";
        private const string DeletePreOrderSP = "PreOrder_Delete";
        private const string DeleteFromCartSP = "PreOrder_DeleteFromCart";

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

        public async Task SavePreOrder(PreOrderSaveModel preOrderSaveModel)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                await connection.ExecuteAsync(SavePreorderSP,
                param: new
                {
                    preOrderSaveModel.UserId,
                    preOrderSaveModel.ProductId
                },
                commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeletePreOrder(int userId)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                await connection.ExecuteAsync(DeletePreOrderSP,
                param: new
                {
                    userId
                },
                commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteFromCart(PreOrderSaveModel preOrderSaveModel)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                await connection.ExecuteAsync(DeleteFromCartSP,
                param: new
                {
                    preOrderSaveModel.UserId,
                    preOrderSaveModel.ProductId,
                },
                commandType: CommandType.StoredProcedure);
            }
        }
    }
}
