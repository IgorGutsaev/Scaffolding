using Scaffolding.Storage.Abstractions;
using System;
using System.Text;
using Xunit;

namespace Scaffolding.Tests.Storage
{
    public class AzureBlobStorageTest
    {
        private readonly DataSource _source;

        public AzureBlobStorageTest()
        {
            _source = new DataSource();
        }

        [Fact]
        public async void Test_Upload_Download()
        {
            // Prepare
            IFileRepository repository = _source.FileRepository;
            string fileUid = Guid.NewGuid().ToString();

            // Pre-validate
            Assert.NotNull(repository);
            //Assert.True(repository.TryConnect);

            // Perform
            byte[] data = Encoding.UTF8.GetBytes("foo bar baz");
            File result = null;
            string returnedUid = string.Empty;
            await repository.UploadAsync(data, fileUid).ContinueWith(r => {
                returnedUid = r.Result;
            });

            result = await repository.DownloadAsync(returnedUid);

            // Post-validate
            Assert.Equal(result?.UID, fileUid);
            Assert.Equal(result?.Data, data);
        }
    }
}
