using DomainService.Shared.Entities;

namespace DomainService.Repositories
{
    public interface IBlocksWebhookRepository
    {
        Task<BlocksWebhook> GetAsync();
        Task SaveAsync(BlocksWebhook webhook);
    }
}