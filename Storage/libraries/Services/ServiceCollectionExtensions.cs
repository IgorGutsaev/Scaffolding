using Microsoft.Extensions.DependencyInjection;
using Scaffolding.Storage.Abstractions;
using Scaffolding.Storage.AzureStorage;
using System;

namespace Scaffolding.Storage.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAzureBlobStorage<T>(this IServiceCollection serviceCollection
            , string connectionString
            , string containerName)
            where T : IFileRepository
        {
            return serviceCollection
             .AddSingleton(typeof(T), (sp) => new BlobRepository((s) => {
                  s.ConnectionString = connectionString;
                  s.ContainerName = containerName;
               }));
        }
    }
}
