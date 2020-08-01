using Amazon;
using Amazon.Integration.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Amazon.Integration.Configuration
{
    public class S3Configuration : IS3Configuration
    {
        private readonly IConfiguration Configuration;

        public S3Configuration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string AccessKeyId => Configuration.GetSection("Amazon").GetSection("S3")["AccessKeyId"];

        public string AccessSecretKey => Configuration.GetSection("Amazon").GetSection("S3")["AccessSecretKey"];

        public string Bucket => Configuration.GetSection("Amazon").GetSection("S3")["Bucket"];

        public RegionEndpoint Region => RegionEndpoint.USEast1;

        public string EndpointAmazon => Configuration.GetSection("Amazon").GetSection("S3")["EndpointAmazon"];
    }
}
