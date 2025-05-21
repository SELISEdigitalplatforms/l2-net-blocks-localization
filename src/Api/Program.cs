using Api;
using Blocks.Genesis;
using DomainService.Utilities;

const string _serviceName = "blocks-localization-api";

var blocksSecrets = await ApplicationConfigurations.ConfigureLogAndSecretsAsync(_serviceName, VaultType.OnPrem);
blocksSecrets.CacheConnectionString = "10.10.6.15:6379,abortConnect=false,connectTimeout=50000,syncTimeout=50000";
blocksSecrets.MessageConnectionString = "amqp://guest:guest@10.10.6.15:5672/";
blocksSecrets.LogConnectionString = "mongodb://10.10.6.15:27017/";
blocksSecrets.MetricConnectionString = "mongodb://10.10.6.15:27017/";
blocksSecrets.TraceConnectionString = "mongodb://10.10.6.15:27017/";
blocksSecrets.LogDatabaseName = "Logs";
blocksSecrets.MetricDatabaseName = "Metrics";
blocksSecrets.TraceDatabaseName = "Traces";
blocksSecrets.DatabaseConnectionString = "mongodb://10.10.6.15:27017/";
blocksSecrets.RootDatabaseName = "Blocks-Root";
blocksSecrets.EnableHsts = true;

var messageConfiguration = new MessageConfiguration
{
    Connection = blocksSecrets.MessageConnectionString,
    RabbitMqConfiguration = new()
    {
        ConsumerSubscriptions = new()
        {
            ConsumerSubscription.BindToQueue("blocks_localization_listener", 2),
        }
    },
    ServiceName = blocksSecrets.ServiceName,
};
var builder = WebApplication.CreateBuilder(args);

ApplicationConfigurations.ConfigureApiEnv(builder, args);

var services = builder.Services;
messageConfiguration.Connection = "mongodb://10.10.6.15:27017/";

ApplicationConfigurations.ConfigureServices(services, messageConfiguration);
ApplicationConfigurations.ConfigureApi(services);

services.RegisterApplicationServices();
services.AddHealthChecks();

var app = builder.Build();

ApplicationConfigurations.ConfigureMiddleware(app);

await app.RunAsync();
