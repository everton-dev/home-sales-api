using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.Cloud;
using Domain.Models.Cloud;
using MediatR;

namespace Application.Handlers.Cloud
{
    public class FileUploadHandler : IRequestHandler<FileUploadCommand, DefaultResponse<FileStorageOutput>>
    {
        private readonly IFileStorageCloud<FileStorageInput, FileStorageOutput> _fileStorageCloud;

        public FileUploadHandler(IFileStorageCloud<FileStorageInput, FileStorageOutput> fileStorageCloud) =>
            _fileStorageCloud = fileStorageCloud;

        public async Task<DefaultResponse<FileStorageOutput>> Handle(FileUploadCommand request, CancellationToken cancellationToken)
        {
            var response = await _fileStorageCloud.AddAsync(new(request.FileName, request.Folder, request.File));

            return new()
            {
                Data = response
            };
        }
    }
}