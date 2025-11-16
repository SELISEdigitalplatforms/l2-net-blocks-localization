namespace DomainService.Services.HelperService
{
    public interface IWebHookService
    {
        Task<bool> CallWebhook(object payload);
    }
}