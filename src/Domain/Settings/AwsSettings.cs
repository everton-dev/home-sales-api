namespace Domain.Settings
{
    public class AwsSettings
    {
        public string S3AccessKeyId { get; set; } = null!;
        public string S3SecretAccessKey { get; set; } = null!;
        public string S3BucketName { get; set; } = null!;
        public string S3UrlBucket { get; set; } = null!;
    }
}