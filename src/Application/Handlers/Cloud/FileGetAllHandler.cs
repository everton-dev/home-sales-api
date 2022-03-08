using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.Cloud;
using Domain.Models.Cloud;
using MediatR;

namespace Application.Handlers
{
    public class FileGetAllHandler : IRequestHandler<FileGetAllCommand, DefaultResponse<ICollection<FileStorageOutput>>>
    {
        private readonly IFileStorageCloud<FileStorageInput, FileStorageOutput> _fileStorageCloud;

        public FileGetAllHandler(IFileStorageCloud<FileStorageInput, FileStorageOutput> fileStorageCloud) =>
            _fileStorageCloud = fileStorageCloud;

        public async Task<DefaultResponse<ICollection<FileStorageOutput>>> Handle(FileGetAllCommand request, CancellationToken cancellationToken)
        {
            var response = await _fileStorageCloud.GetAllAsync(request.Folder);

            return new()
            {
                Data = response
            };
        }
    }
}