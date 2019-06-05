using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffolding.Storage.AzureStorage
{
    public class BlobRepositorySettings
    {
        public string ConnectionString { get; set; }
        public string ContainerName { get; set; }
    }
}
