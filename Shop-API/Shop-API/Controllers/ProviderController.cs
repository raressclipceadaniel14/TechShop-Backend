using Microsoft.AspNetCore.Mvc;
using Shop_API.BusinessLogic.Interface;
using Shop_API.Models.Provider;

namespace Shop_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderBL _providerBL;

        public ProviderController(IProviderBL providerBL)
        {
            this._providerBL = providerBL;
        }

        [HttpGet("get-providers")]
        public async Task<IEnumerable<ProviderModel>> GetProviders()
        {
            var providers = await _providerBL.GetProviders();
            return providers;
        }

        [HttpGet("get-provider-by-id")]
        public async Task<ProviderModel> GetProviderById([FromQuery] int providerId)
        {
            var provider = await _providerBL.GetProviderById(providerId);
            return provider;
        }
    }
}
