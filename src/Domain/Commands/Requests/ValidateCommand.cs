using Flunt.Notifications;

namespace Domain.Commands.Requests
{
    public abstract class ValidateCommand : Notifiable<Notification>
    {
        public abstract Task ValidateAsync();
    }
}