using Domain.Commands.Responses;
using MediatR;

namespace Domain.Commands.Requests
{
    public class RoomGetAllCommand : ValidateCommand, IRequest<DefaultResponse<ICollection<Models.Room>>>
    {
        public override async Task ValidateAsync()
        {
            await Task.CompletedTask;
        }
    }
}