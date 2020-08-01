using Amazon.Integration.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Amazon.Integration.Configuration
{
    public class SNSConfiguration : ISNSConfiguration
    {
        private readonly IConfiguration Configuration;

        public SNSConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public RegionEndpoint Region => RegionEndpoint.USEast1;

        public string AccessKeyId => Configuration.GetSection("Amazon").GetSection("SNS")["AccessKeyId"];

        public string AccessSecretKey => Configuration.GetSection("Amazon").GetSection("SNS")["AccessSecretKey"];
    }
}
