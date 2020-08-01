
using Amazon.Integration.Models;

namespace Amazon.Integration.Interfaces
{
    public interface INotificationService
    {
        NotificationResponse Send(NotificationRequest notificationRequest);
    }
}
