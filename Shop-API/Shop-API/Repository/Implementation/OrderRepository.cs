using api.Repositories.Implementations;
using Dapper;
using Shop_API.BusinessLogic.Implementation;
using Shop_API.Models.Order;
using Shop_API.Models.Product;
using Shop_API.Repository.Interface;
using System.Data;
using System.Reflection;

namespace Shop_API.Repository.Implementation
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        private const string SaveFavoriteSP = "Order_Create";
        private const string GetLastOrderByUserSP = "Order_Get";
        private const string SavePoductsInOrderSP = "OrderProduct_InsertOrder";

        public OrderRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> AddOrder(AddOrderModel order)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                return await connection.QueryFirstOrDefaultAsync<int>(SaveFavoriteSP,
                param: new
                {
                    order.Address,
                    order.UserId
                },
                commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<OrderModel> GetLastOrderByUser(int userId)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                return (await connection.QueryFirstOrDefaultAsync<OrderModel>(GetLastOrderByUserSP,
                    param: new
                    {
                        userId
                    },
                    commandType: CommandType.StoredProcedure));
            }
        }

        public async Task SaveProductsInOrder(List<int> productsId, int orderId)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                var productTable = new DataTable();
                productTable.Columns.Add("Id", typeof(int));
                foreach (var productId in productsId)
                {
                    productTable.Rows.Add(productId);
                }

                await connection.ExecuteAsync(
                    SavePoductsInOrderSP,
                    new
                    {
                        OrderId = orderId,
                        Products = productTable
                    },
                    commandType: CommandType.StoredProcedure
                );
            }
        }
    }
}
