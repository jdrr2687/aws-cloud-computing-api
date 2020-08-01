using System.Collections.Generic;

namespace Amazon.Integration.Models
{
    public class EmailRequest
    {
        
        public string Subject { get; set; }
        
        public string HtmlBody { get; set; }
        
        public string TextBody { get; set; }
        
        public List<string> Receivers { get; set; }

        public EmailRequest()
        {
            Receivers = new List<string>();
        }
    }
}
