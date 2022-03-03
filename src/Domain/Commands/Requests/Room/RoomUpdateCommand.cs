using Domain.Commands.Responses;
using Domain.Validators;
using MediatR;
using System.Text.Json.Serialization;

namespace Domain.Commands.Requests
{
    public class RoomUpdateCommand : ValidateCommand, IRequest<DefaultResponse>
    {
        public string Id { get; private set; }
        public string? Description { get; private set; }

        [JsonConstructor]
        public RoomUpdateCommand(string id, string? description)
        {
            Id = id;
            Description = description;
        }

        public override async Task ValidateAsync()
        {
            if (string.IsNullOrEmpty(Id.ToString()))
                AddNotification("Id", "Id is required.");
            else if (!GuidValidator.IsGuid(Id.ToString()))
                AddNotification("Id", "Id is not valid.");

            if (string.IsNullOrWhiteSpace(Description))
                AddNotification("Description", "Description is required.");

            await Task.CompletedTask;
        }
    }
}