using Amazon.Integration.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaberApi.Servicios.Generales.Services.Interfaces
{
    public interface IUploadFileService
    {
        Task<List<string>> UploadFile(List<IFormFile> files);

    }
}
