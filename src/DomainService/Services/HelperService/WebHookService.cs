using DomainService.Repositories;
using Microsoft.Extensions.Logging;

namespace DomainService.Services.HelperService
{
    public class WebHookService : IWebHookService
    {
        private readonly IBlocksWebhookRepository _blocksWebhookRepository;
        private readonly IHttpHelperServices _httpHelperServices;
        private readonly ILogger<WebHookService> _logger;

        public WebHookService(IBlocksWebhookRepository blocksWebhookRepository, IHttpHelperServices httpHelperServices, ILogger<WebHookService> logger)
        {
            _blocksWebhookRepository = blocksWebhookRepository;
            _httpHelperServices = httpHelperServices;
            _logger = logger;
        }

        public async Task<bool> CallWebhook(object payload)
        {
            var webhook = await _blocksWebhookRepository.GetAsync();
            if (webhook == null || webhook.IsDisabled) return true;

            return await _httpHelperServices.MakeHttpRequestForWebhook(payload, webhook);
        }
    }
}