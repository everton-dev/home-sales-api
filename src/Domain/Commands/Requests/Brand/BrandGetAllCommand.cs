using Domain.Commands.Responses;
using MediatR;

namespace Domain.Commands.Requests
{
    public class BrandGetAllCommand : ValidateCommand, IRequest<DefaultResponse<ICollection<Models.Brand>>>
    {
        public override async Task ValidateAsync()
        {
            await Task.CompletedTask;
        }
    }
}