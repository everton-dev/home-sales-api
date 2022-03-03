using Domain.Commands.Responses;
using Domain.Validators;
using MediatR;
using System.Text.Json.Serialization;

namespace Domain.Commands.Requests
{
    public class ProductGetByIdCommand : ValidateCommand, IRequest<DefaultResponse<Models.Product>>
    {
        public string Id { get; private set; }

        [JsonConstructor]
        public ProductGetByIdCommand(string id) => Id = id;

        public override async Task ValidateAsync()
        {
            if (string.IsNullOrWhiteSpace(Id))
                AddNotification("Id", "Id is required.");
            else if (!GuidValidator.IsGuid(Id))
                AddNotification("Id", "Id is not valid.");

            await Task.CompletedTask;
        }
    }
}