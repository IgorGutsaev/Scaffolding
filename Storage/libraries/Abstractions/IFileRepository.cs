using System;
using System.Threading.Tasks;

namespace Scaffolding.Storage.Abstractions
{
    public interface IFileRepository
    {
        Task<File> DownloadAsync(string uid);

        Task<string> UploadAsync(byte[] data, string uid);
    }
}
