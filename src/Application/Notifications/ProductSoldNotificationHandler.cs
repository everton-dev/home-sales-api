using Domain.Notifications;
using MediatR;

namespace Application.Notifications
{
    public class ProductSoldNotificationHandler : INotificationHandler<ProductSoldNotification>
    {
        public async Task Handle(ProductSoldNotification notification, CancellationToken cancellationToken) =>
            await Task.Run(() => System.Diagnostics.Debug.WriteLine($"=>{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} | {notification.Message}"));
    }
}