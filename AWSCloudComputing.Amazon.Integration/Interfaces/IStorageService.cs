using Amazon.Integration.Models;
using System.Threading.Tasks;

namespace Amazon.Integration.Interfaces
{
    public interface IStorageService
    {
        Task<StorageResponse> UploadObject(StorageRequest storageRequest);
        Task<StorageResponse> RemoveObject(StorageDeleteRequest storageDeleteRequest);
    }
}
