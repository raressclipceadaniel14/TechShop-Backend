using Shop_API.Models.Provider;

namespace Shop_API.BusinessLogic.Interface
{
    public interface IProviderBL
    {
        Task<ProviderModel> GetProviderById(int providerId);
        Task<List<ProviderModel>> GetProviders();
    }
}
