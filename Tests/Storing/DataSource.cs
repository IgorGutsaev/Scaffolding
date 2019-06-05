using Microsoft.Extensions.DependencyInjection;
using Scaffolding.Storage.Abstractions;
using Scaffolding.Storage.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffolding.Tests.Storage
{
    public class DataSource
    {
        const string AZURE_STORAGE_CS = "DefaultEndpointsProtocol=https;AccountName=ascrepository;AccountKey=RQ2F/cswHcXDGFTRi/mBupYLg6sAsem+3YvAYa93B89/PyYMlrIuIR1pSfpwWOEqToNajJMWySSAXQGpyfIVOQ==;EndpointSuffix=core.windows.net";
        const string AZURE_CONTAINER_NAME = "reports";

        private readonly IServiceProvider _provider;

        public IFileRepository FileRepository => _provider.GetRequiredService<IFileRepository>();

        public DataSource()
        {
            _provider = new ServiceCollection()
                .AddAzureBlobStorage<IFileRepository>(AZURE_STORAGE_CS, AZURE_CONTAINER_NAME)
                .BuildServiceProvider();
        }
    }
}
