using Blocks.Genesis;
using DomainService.Services;
using MongoDB.Driver;
using Polly;



namespace DomainService.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly IDbContextProvider _dbContextProvider;
        private const string _collectionName = "BlocksLanguageModules";

        public ModuleRepository(IDbContextProvider dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<BlocksLanguageModule> GetByNameAsync(string name)
        {
            var dataBase = _dbContextProvider.GetDatabase(BlocksContext.GetContext()?.TenantId?? "");
            var collection = dataBase.GetCollection<BlocksLanguageModule>(_collectionName);

            var filter = Builders<BlocksLanguageModule>.Filter.Eq(mc => mc.ModuleName, name);
            return await collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<Module>> GetAllAsync()
        {
            var collection = _dbContextProvider.GetCollection<Module>(_collectionName);
            return await collection.Find(_ => true).ToListAsync();
        }

        public async Task SaveAsync(BlocksLanguageModule module)
        {
            var dataBase = _dbContextProvider.GetDatabase(BlocksContext.GetContext()?.TenantId ?? "");
            var collection = dataBase.GetCollection<BlocksLanguageModule>(_collectionName);

            var filter = Builders<BlocksLanguageModule>.Filter.Eq(mc => mc.ModuleName, module.ModuleName);

            await collection.ReplaceOneAsync(
                filter,
                module,
                new ReplaceOptions { IsUpsert = true }
            );

        }
    }
}
