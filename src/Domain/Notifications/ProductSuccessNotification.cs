using MediatR;

namespace Domain.Notifications
{
    public class ProductSuccessNotification : INotification
    {
        public string Message { get; init; }

        public ProductSuccessNotification(string message)
        {
            Message = message;
        }
    }
}