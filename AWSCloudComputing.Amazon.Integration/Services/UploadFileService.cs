using Amazon.Integration.Interfaces;
using Amazon.Integration.Configuration;
using System.Threading.Tasks;
using Amazon.Integration.Models;
using Saber.BusinessServices.External.Amazon.S3;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using SaberApi.Servicios.Generales.Services.Interfaces;

using System.IO;
using System;
using Microsoft.Extensions.Configuration;

namespace SaberApi.Servicios.Generales.Services
{
    public class UploadFileService : IUploadFileService
    {

        protected readonly IStorageService StorageService;

        public UploadFileService(IStorageService storageService)
        {
            StorageService = storageService;
        }

        public async Task<List<string>> UploadFile(List<IFormFile> files)
        {
            List<string> responses = new List<string>();
            foreach (var formFile in files)
            {
                DateTime timeStamp = DateTime.Now;
                if (formFile.Length > 0)
                {
                    var FileName = Path.GetFileNameWithoutExtension(formFile.FileName) + '_' + timeStamp.ToString("yyyyMMddHHmmssffff") + Path.GetExtension(formFile.FileName);

                    StorageRequest storageRequest = new StorageRequest()
                    {
                        FolderName = "recursos/",
                        FileName = FileName,
                        File = formFile
                    };

                    StorageResponse storageResponse = await StorageService.UploadObject(storageRequest);
                    responses.Add(storageResponse.FileName);
                }
            }
            return responses;
        }
       
    }
}
