using Amazon.Integration.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Amazon.Integration.Configuration
{
    public class EmailConfiguration : IEmailConfiguration
    {
        private readonly IConfiguration Configuration;

        public EmailConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string SenderAddress => Configuration.GetSection("Amazon").GetSection("SES")["SenderAddress"];

        public string FrontEndUrl => Configuration.GetSection("Amazon").GetSection("SES")["FrontEndUrl"];

        public string ForgotPasswordRoute => Configuration.GetSection("Amazon").GetSection("SES")["ForgotPasswordRoute"];

        public string ActivateAccountRoute => Configuration.GetSection("Amazon").GetSection("SES")["ActivateAccountRoute"];

        public string AccessKeyId => Configuration.GetSection("Amazon").GetSection("SES")["AccessKeyId"];

        public string AccessSecretKey => Configuration.GetSection("Amazon").GetSection("SES")["AccessSecretKey"];
    }
}
