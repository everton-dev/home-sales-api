using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Domain.Extensions;
using Domain.Interfaces.Cloud;
using Domain.Models.Cloud;
using Domain.Settings;
using Microsoft.Extensions.Options;

namespace Infrastructure.Cloud.AWS
{
    public class FileStorageCloud : BaseFileStorageCloud, IFileStorageCloud<FileStorageInput, FileStorageOutput>
    {
        public FileStorageCloud(IOptions<AwsSettings> awsSettings)
            : base(awsSettings)
        {
        }

        public async Task<FileStorageOutput> AddAsync(FileStorageInput file)
        {
            try
            {
                var bucketRepository = $"{_bucketName}/{file.Folder}".Replace("//", "/");
                var urlBucket = _awsSettings.Value.S3UrlBucket;
                var urlFile = string.Empty;

                using (var ms = new MemoryStream(Convert.FromBase64String(file.File)))
                {
                    var uploadRequest = new TransferUtilityUploadRequest
                    {
                        InputStream = ms,
                        Key = file.FileName,
                        BucketName = bucketRepository,
                        CannedACL = S3CannedACL.PublicRead,
                    };

                    var fileTransferUtility = new TransferUtility(_client);
                    await fileTransferUtility.UploadAsync(uploadRequest);

                    urlFile = $"{urlBucket}/{file.Folder}/{file.FileName}".Replace("//", "/");
                }

                return new(file.FileName, bucketRepository, urlFile);
            }
            catch (AmazonS3Exception ex)
            {
                //_logger.LogError("Algo deu errado durante o upload do arquivo.", ex);

                if (ex.ErrorCode != null && 
                   (ex.ErrorCode.Equals("InvalidAccessKeyId") || 
                    ex.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Credential is invalid.", ex);
                }
                else
                {
                    throw new Exception("Error: " + ex.Message);
                }

                throw ex;
            }
            catch (Exception ex)
            {
                //_logger.LogError("Erro genérico ao criar arquivo no S3", ex);
                throw;
            }
        }

        public async Task<ICollection<FileStorageOutput>> GetAllAsync(string folder)
        {
            var result = new List<FileStorageOutput>();
            var bucketRepository = $"{_bucketName}/{folder}".Replace("//", "/");
            var urlBucket = _awsSettings.Value.S3UrlBucket;

            ListObjectsRequest listRequest = new ListObjectsRequest
            {
                BucketName = bucketRepository,
            };

            ListObjectsResponse listResponse;
            do
            {
                // Get a list of objects
                listResponse = await _client.ListObjectsAsync(listRequest);
                foreach (S3Object awsFile in listResponse.S3Objects)
                {
                    var urlFile = $"{urlBucket}/{folder}/{awsFile.Key}".Replace("//", "/");

                    result.Add(new FileStorageOutput(awsFile.Key, bucketRepository, urlFile));
                }

                // Set the marker property
                listRequest.Marker = listResponse.NextMarker;
            } while (listResponse.IsTruncated);

            return result;
        }

        public async Task<FileStorageOutput> GetAsync(FileStorageInput file)
        {
            var bucketRepository = $"{_bucketName}/{file.Folder}".Replace("//", "/");
            var urlBucket = _awsSettings.Value.S3UrlBucket;
            var urlFile = string.Empty;
            var base64 = string.Empty;

            var request = new GetObjectRequest
            {
                BucketName = bucketRepository,
                Key = file.FileName
            };

            // Issue request and remember to dispose of the response
            using (GetObjectResponse response = await _client.GetObjectAsync(request))
            {
                using (Stream responseStream = response.ResponseStream)
                {
                    base64 = responseStream.ConvertToBase64();
                    urlFile = $"{urlBucket}/{file.Folder}/{file.FileName}".Replace("//", "/");
                }
            }

            return new(file.FileName, bucketRepository, urlFile, base64);
        }

        public Task RemoveAsync(FileStorageInput file)
        {
            throw new NotImplementedException();
        }
    }
}