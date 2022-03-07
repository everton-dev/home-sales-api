namespace Domain.Models.Cloud
{
    public class FileStorageInput
    {
        public string FileName { get; private set; }
        public string Folder { get; private set; }
        public string File { get; private set; }

        public FileStorageInput(string fileName, string folder, string file)
        {
            FileName = fileName;
            Folder = folder;
            File = file;
        }

        public FileStorageInput(string fileName, string folder)
        {
            FileName = fileName;
            Folder = folder;
            File = string.Empty;
        }
    }
}