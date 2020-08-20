using Microsoft.Extensions.DependencyInjection;
using Scaffolding.Storage.Abstractions;
using Scaffolding.Storage.AzureStorage;
using System;

namespace Scaffolding.Storage.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAzureBlobStorage(this IServiceCollection serviceCollection
            , string connectionString
            , string containerName)
        {
            return serviceCollection
             .AddSingleton<IFileRepository>(new BlobRepository((s) => {
                  s.ConnectionString = connectionString;
                  s.ContainerName = containerName;
               }));
        }
    }
}
