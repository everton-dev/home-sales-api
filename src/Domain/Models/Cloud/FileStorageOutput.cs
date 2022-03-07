namespace Domain.Models.Cloud
{
    public class FileStorageOutput
    {
        public string FileName { get; private set; }
        public string UrlBucket { get; private set; }
        public string UrlFile { get; private set; }
        public string File { get; private set; }

        public FileStorageOutput(string fileName, string urlBucket, string urlFile, string? file = null)
        {
            FileName = fileName;
            UrlBucket = urlBucket;
            UrlFile = urlFile;
            File = file ?? string.Empty;
        }
    }

    public class FileStorageOutput<TResponse> : FileStorageOutput where TResponse : class
    {
        public TResponse? Data { get; private set; }

        public FileStorageOutput(string fileName, string urlBucket, string urlFile, string? file = null, TResponse? data = null)
            : base(fileName, urlBucket, urlFile, file)
        {
            Data = data;
        }
    }
}