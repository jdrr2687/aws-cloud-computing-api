
using System.ComponentModel;

namespace Amazon.Integration.Models
{
    public enum MessageType
    {
        [Description("Transactional")]
        Transactional,
        [Description("Promotional")]
        Promotional
    }

    public class NotificationRequest
    {
        public string SenderId { get; set; }
        public string PhoneNumber { get; set; }
        public string TextMessage { get; set; }
        public MessageType Type { get; set; }
    }
}
