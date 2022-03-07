using Domain.Commands.Responses;
using Domain.Models.Cloud;
using MediatR;
using System.Text.Json.Serialization;

namespace Domain.Commands.Requests
{
    public class FileUploadCommand : ValidateCommand, IRequest<DefaultResponse<FileStorageOutput>>
    {
        public string Folder { get; private set; }
        public string FileName { get; private set; }
        public string File { get; private set; }

        [JsonConstructor]
        public FileUploadCommand(string folder, string fileName, string file)
        {
            Folder = folder;
            FileName = fileName;
            File = file;
        }

        public override async Task ValidateAsync()
        {
            if (string.IsNullOrWhiteSpace(File))
                AddNotification("File", "File is required.");

            await Task.CompletedTask;
        }
    }
}