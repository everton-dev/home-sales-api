using Domain.Commands.Responses;
using MediatR;
using System.Text.Json.Serialization;

namespace Domain.Commands.Requests
{
    public class RoomCreateCommand : ValidateCommand, IRequest<DefaultResponse>
    {
        public string Description { get; private set; }

        [JsonConstructor]
        public RoomCreateCommand(string description)
        {
            Description = description;
        }

        public override async Task ValidateAsync()
        {
            if (string.IsNullOrWhiteSpace(Description))
                AddNotification("Description", "Description is required.");

            await Task.CompletedTask;
        }
    }
}