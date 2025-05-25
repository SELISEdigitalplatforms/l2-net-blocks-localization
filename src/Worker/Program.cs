using Blocks.Genesis;
using DomainService.Utilities;
using Worker;

const string _serviceName = "blocks-localization-worker";

await ApplicationConfigurations.ConfigureLogAndSecretsAsync(_serviceName, VaultType.Azure);

await CreateHostBuilder(args).Build().RunAsync();

IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((context, builder) =>
        {
            ApplicationConfigurations.ConfigureWorkerEnv(builder, args);
        })
        .ConfigureServices(async (services) =>
        {
            //ApplicationConfigurations.ConfigureServices(services, DomainService.Utilities.Constants.GetMessageConfiguration());
            services.AddHttpClient();
            services.RegisterApplicationServices();
            ApplicationConfigurations.ConfigureWorker(services, Constants.GetMessageConfiguration());
        });