using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Interfaces.Cloud;
using Domain.Models.Cloud;
using MediatR;

namespace Application.Handlers
{
    public class FileGetHandler : IRequestHandler<FileGetCommand, DefaultResponse<FileStorageOutput>>
    {
        private readonly IFileStorageCloud<FileStorageInput, FileStorageOutput> _fileStorageCloud;

        public FileGetHandler(IFileStorageCloud<FileStorageInput, FileStorageOutput> fileStorageCloud) =>
            _fileStorageCloud = fileStorageCloud;

        public async Task<DefaultResponse<FileStorageOutput>> Handle(FileGetCommand request, CancellationToken cancellationToken)
        {
            var response = await _fileStorageCloud.GetAsync(new(request.FileName, request.Folder));

            return new()
            {
                Data = response
            };
        }
    }
}