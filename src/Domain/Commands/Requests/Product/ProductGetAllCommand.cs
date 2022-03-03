using Domain.Commands.Responses;
using MediatR;

namespace Domain.Commands.Requests
{
    public class ProductGetAllCommand : ValidateCommand, IRequest<DefaultResponse<ICollection<Models.Product>>>
    {
        public override async Task ValidateAsync()
        {
            await Task.CompletedTask;
        }
    }
}