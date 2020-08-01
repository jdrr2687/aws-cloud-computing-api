namespace Amazon.Integration.Interfaces
{
    public interface ISNSConfiguration : IAccessAmazonConfiguration
    {
        RegionEndpoint Region { get; }
    }
}
