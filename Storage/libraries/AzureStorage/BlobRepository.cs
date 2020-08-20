using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Scaffolding.Common.Helpers;
using Scaffolding.Storage.Abstractions;
using System;
using System.Threading.Tasks;

namespace Scaffolding.Storage.AzureStorage
{
    public class BlobRepository : IFileRepository
    {
        private readonly BlobRepositorySettings _settings;

        private readonly CloudBlobContainer _container;

        public BlobRepository(Action<BlobRepositorySettings> setupAction)
        {
            _settings = setupAction?.CreateTargetAndInvoke();

            CloudStorageAccount storageacc = CloudStorageAccount.Parse(_settings.ConnectionString);
            //Create Reference to Azure Blob
            CloudBlobClient blobClient = storageacc.CreateCloudBlobClient();
            //The next 2 lines create if not exists a container named "democontainer"
            _container = blobClient.GetContainerReference(_settings.ContainerName);
        }

        public async Task<File> DownloadAsync(string uid)
        {
            CloudBlockBlob blockBlob = _container.GetBlockBlobReference(uid);
            
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                return await blockBlob.DownloadToStreamAsync(ms).ContinueWith(r =>
                {
                    ms.Position = 0;
                    return File.Create(uid, ms.ToArray());
                });
            }
        }

        public async Task<string> UploadAsync(byte[] data, string uid)
        {
            await _container.CreateIfNotExistsAsync();

            //The next 7 lines upload the file test.txt with the name DemoBlob on the container "democontainer"
            CloudBlockBlob blockBlob = _container.GetBlockBlobReference(uid);
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                ms.Write(data, 0, data.Length);
                ms.Position = 0;
                await blockBlob.UploadFromStreamAsync(ms);
            }

            return uid;
        }
    }
}
