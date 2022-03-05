using Amazon.S3;
using Amazon.S3.Model;

namespace Infrastructure.Cloud.AWS
{
    public abstract class BaseFileStorageCloud
    {
        protected readonly AmazonS3Client _client;
        protected readonly string _bucketName;

        public BaseFileStorageCloud()
        {
            _client = new AmazonS3Client();

            _bucketName = "s3://portugal-bucket/catalogo/";
        }
    }
}