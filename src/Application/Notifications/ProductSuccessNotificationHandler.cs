using Domain.Notifications;
using MediatR;

namespace Application.Notifications
{
    public class ProductSuccessNotificationHandler : INotificationHandler<ProductSuccessNotification>
    {
        public async Task Handle(ProductSuccessNotification notification, CancellationToken cancellationToken) =>
            await Task.Run(() => System.Diagnostics.Debug.WriteLine($"=>{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} | {notification.Message}"));
    }
}