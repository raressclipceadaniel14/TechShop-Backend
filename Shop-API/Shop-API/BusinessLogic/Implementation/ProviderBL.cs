using Shop_API.BusinessLogic.Interface;
using Shop_API.Models.Provider;
using Shop_API.Repository.Interface;

namespace Shop_API.BusinessLogic.Implementation
{
    public class ProviderBL : IProviderBL
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderBL(IProviderRepository providerRepository)
        {
            this._providerRepository = providerRepository;
        }

        public async Task<List<ProviderModel>> GetProviders()
        {
            var providers = await _providerRepository.GetProviders();
            return providers;
        }

        public async Task<ProviderModel> GetProviderById(int providerId)
        {
            var provider = await _providerRepository.GetProviderById(providerId);
            return provider;
        }
    }
}
