using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using Amazon.Integration.Interfaces;
using System.IO;
using Amazon.Integration.Models;

namespace Saber.BusinessServices.External.Amazon.S3
{
    public class StorageService : IStorageService
    {
        private readonly IS3Configuration S3Configuration;

        public StorageService(IS3Configuration s3Configuration)
        {
            S3Configuration = s3Configuration;
        }

        public async Task<StorageResponse> UploadObject(StorageRequest storageRequest)
        {
            var client = new AmazonS3Client(S3Configuration.AccessKeyId, S3Configuration.AccessSecretKey, S3Configuration.Region);

            byte[] fileBytes = new Byte[storageRequest.File.Length];
            storageRequest.File.OpenReadStream().Read(fileBytes, 0, Int32.Parse(storageRequest.File.Length.ToString()));

            var fileNameTemp = storageRequest.FileName ?? Guid.NewGuid() + storageRequest.File.FileName.Trim();

            PutObjectResponse response = null;

            using (var stream = new MemoryStream(fileBytes))
            {
                var request = new PutObjectRequest
                {
                    BucketName = S3Configuration.Bucket,
                    Key = (storageRequest.FolderName ?? "") + fileNameTemp,
                    InputStream = stream,
                    ContentType = storageRequest.File.ContentType,
                    CannedACL = S3CannedACL.PublicRead
                    
                    
                };

                response = await client.PutObjectAsync(request);
            }

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                return new StorageResponse
                {
                    Success = true,
                    FileName = string.Format(S3Configuration.EndpointAmazon, S3Configuration.Bucket) + (storageRequest.FolderName ?? "") + fileNameTemp
                };
            }
            else
            {
                return new StorageResponse
                {
                    Success = false,
                    FileName = storageRequest.FileName
                };
            }
         }

        public async Task<StorageResponse> RemoveObject(StorageDeleteRequest storageDeleteRequest)
        {
            var client = new AmazonS3Client(S3Configuration.AccessKeyId, S3Configuration.AccessSecretKey, S3Configuration.Region);

            var request = new DeleteObjectRequest
            {
                BucketName = S3Configuration.Bucket,
                Key = storageDeleteRequest.FileName
            };

            var response = await client.DeleteObjectAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return new StorageResponse
                {
                    Success = true,
                    FileName = storageDeleteRequest.FileName
                };
            }
            else
            {
                return new StorageResponse
                {
                    Success = false,
                    FileName = storageDeleteRequest.FileName
                };
            }
        }

    }
}

