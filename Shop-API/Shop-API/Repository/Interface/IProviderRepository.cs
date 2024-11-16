using Shop_API.Models.Provider;

namespace Shop_API.Repository.Interface
{
    public interface IProviderRepository
    {
        Task<ProviderModel> GetProviderById(int providerId);
        Task<List<ProviderModel>> GetProviders();
    }
}
