using Amazon;

namespace Amazon.Integration.Interfaces
{
    public interface IS3Configuration : IAccessAmazonConfiguration
    {
        string Bucket { get;  }

        string EndpointAmazon { get; }

        RegionEndpoint Region { get;  }
    }
}
