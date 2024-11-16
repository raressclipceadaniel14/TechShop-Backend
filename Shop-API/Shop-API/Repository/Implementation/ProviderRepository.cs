using api.Repositories.Implementations;
using Dapper;
using Shop_API.BusinessLogic.Implementation;
using Shop_API.Models.Product;
using Shop_API.Models.Provider;
using Shop_API.Repository.Interface;
using System.Data;

namespace Shop_API.Repository.Implementation
{
    public class ProviderRepository : BaseRepository, IProviderRepository
    {
        private const string GetProvidersSP = "Provider_GetProviders";
        private const string GetProviderByIdSP = "Provider_GetProviderById";

        public ProviderRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<ProviderModel>> GetProviders()
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                return (await connection.QueryAsync<ProviderModel>(GetProvidersSP,
                    commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<ProviderModel> GetProviderById(int providerId)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                return (await connection.QueryFirstOrDefaultAsync<ProviderModel>(GetProviderByIdSP,
                    param: new
                    {
                        providerId
                    },
                    commandType: CommandType.StoredProcedure));
            }
        }
    }
}
