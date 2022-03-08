using Domain.Commands.Responses;
using Domain.Models.Cloud;
using MediatR;
using System.Text.Json.Serialization;

namespace Domain.Commands.Requests
{
    public class FileGetAllCommand : ValidateCommand, IRequest<DefaultResponse<ICollection<FileStorageOutput>>>
    {
        public string Folder { get; private set; }

        [JsonConstructor]
        public FileGetAllCommand(string folder) =>
            Folder = folder;

        public override async Task ValidateAsync() =>
            await Task.CompletedTask;
    }
}