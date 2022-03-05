using Amazon.S3.Model;
using Domain.Interfaces.Cloud;
using Domain.Models.Cloud;

namespace Infrastructure.Cloud.AWS
{
    public class FileStorageCloud : BaseFileStorageCloud, IFileStorageCloud<FileStorageInput, FileStorageOutput>
    {
        public async Task<FileStorageOutput> AddAsync(FileStorageInput file)
        {
            var request = new PutObjectRequest()
            {
                BucketName = _bucketName
            };

            request.ContentBody = "";

            await _client.PutObjectAsync(request);

            return new();
        }

        public Task<ICollection<FileStorageOutput>> GetAllAsync(FileStorageInput file)
        {
            throw new NotImplementedException();
        }

        public Task<FileStorageOutput> GetAsync(FileStorageInput file)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(FileStorageInput file)
        {
            throw new NotImplementedException();
        }
    }
}