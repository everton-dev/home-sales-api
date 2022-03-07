using Domain.Commands.Responses;
using Domain.Models.Cloud;
using MediatR;
using System.Text.Json.Serialization;

namespace Domain.Commands.Requests
{
    public class FileGetCommand : ValidateCommand, IRequest<DefaultResponse<FileStorageOutput>>
    {
        public string Folder { get; private set; }
        public string FileName { get; private set; }

        [JsonConstructor]
        public FileGetCommand(string folder, string fileName)
        {
            Folder = folder;
            FileName = fileName;
        }

        public override async Task ValidateAsync()
        {
            if (string.IsNullOrWhiteSpace(Folder))
                AddNotification("Folder", "Folder is required.");

            if (string.IsNullOrWhiteSpace(FileName))
                AddNotification("FileName", "FileName is required.");

            await Task.CompletedTask;
        }
    }
}