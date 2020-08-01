
using Microsoft.AspNetCore.Http;

namespace Amazon.Integration.Models
{
    public class StorageRequest
    {
        public IFormFile File { get; set; }

        public string FolderName { get; set; }

        public string FileName { get; set; } = null;
    }
}
