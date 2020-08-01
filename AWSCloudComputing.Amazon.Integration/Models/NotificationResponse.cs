using System.Collections.Generic;

namespace Amazon.Integration.Models
{
    public class NotificationResponse
    {
        public bool IsValid { get; set; }
        public IList<string> Errors = new List<string>();
    }
}
