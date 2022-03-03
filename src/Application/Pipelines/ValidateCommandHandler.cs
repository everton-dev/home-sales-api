using Domain.Commands.Requests;
using Domain.Commands.Responses;
using MediatR;
using Newtonsoft.Json;

namespace Application.Pipelines
{
    public class ValidateCommandHandler<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : DefaultResponse
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is ValidateCommand validateCommand)
            {
                await validateCommand.ValidateAsync();
                if (!validateCommand.IsValid)
                {
                    var validations = new DefaultResponse();

                    foreach (var notification in validateCommand.Notifications)
                        await validations.AddValidationAsync(notification.Message);

                    var serializedParent = JsonConvert.SerializeObject(validations);
                    var response = JsonConvert.DeserializeObject<TResponse>(serializedParent);
                                        
                    return response;
                }
            }

            TResponse result = await next();
            return result;
        }
    }
}