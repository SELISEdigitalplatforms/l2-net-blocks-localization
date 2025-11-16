using Blocks.Genesis;
using DomainService.Services;
using DomainService.Services.HelperService;
using DomainService.Shared.Events;

namespace Worker.Consumers
{

    public class UilmImportEventConsumer : IConsumer<UilmImportEvent>
    {
        private readonly IKeyManagementService _keyManagementService;
        private readonly IWebHookService _webHookService;

        public UilmImportEventConsumer(IKeyManagementService keyManagementService, IWebHookService webHookService)
        {
            _keyManagementService = keyManagementService;
            _webHookService = webHookService;
        }
        public async Task Consume(UilmImportEvent @event)
        {
            var isSuccess = await _keyManagementService.ImportUilmFile(@event);
            if (isSuccess)
            {
                _webHookService.CallWebhook(new { UilmImportEvent = @event, IsSuccess = isSuccess});
            }

        }
    }
}