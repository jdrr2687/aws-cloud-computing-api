
using System.Collections.Generic;

namespace Amazon.Integration.Models
{
    public class EmailTemplateRequest
    {
        public string Subject { get; set; }
        public string Template { get; set; }

        public List<string> Receivers { get; set; }

        public object Data { get; set; }

        public EmailTemplateRequest()
        {
            Receivers = new List<string>();
        }
    }
}
