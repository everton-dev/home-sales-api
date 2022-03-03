using Domain.Commands.Responses;
using Domain.Validators;
using MediatR;
using System.Text.Json.Serialization;

namespace Domain.Commands.Requests
{
    public class RoomGetByIdCommand : ValidateCommand, IRequest<DefaultResponse<Models.Room>>
    {
        public string Id { get; private set; }

        [JsonConstructor]
        public RoomGetByIdCommand(string id) => Id = id;

        public override async Task ValidateAsync()
        {
            if (!GuidValidator.IsGuid(Id.ToString()))
                AddNotification("Id", "Id is required.");

            await Task.CompletedTask;
        }
    }
}