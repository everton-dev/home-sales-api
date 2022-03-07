using Amazon;
using Amazon.S3;
using Domain.Settings;
using Microsoft.Extensions.Options;

namespace Infrastructure.Cloud.AWS
{
    public abstract class BaseFileStorageCloud
    {
        protected readonly IOptions<AwsSettings> _awsSettings;
        protected readonly IAmazonS3 _client;
        protected readonly string _bucketName;

        public BaseFileStorageCloud(IOptions<AwsSettings> awsSettings)
        {
            _awsSettings = awsSettings;
            _client = new AmazonS3Client(_awsSettings.Value.S3AccessKeyId, _awsSettings.Value.S3SecretAccessKey, RegionEndpoint.USEast1);
            _bucketName = _awsSettings.Value.S3BucketName;
        }
    }
}