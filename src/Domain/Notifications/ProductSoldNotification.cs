using MediatR;

namespace Domain.Notifications
{
    public class ProductSoldNotification : INotification
    {
        public string Message { get; init; }

        public ProductSoldNotification(string message)
        {
            Message = message;
        }
    }
}