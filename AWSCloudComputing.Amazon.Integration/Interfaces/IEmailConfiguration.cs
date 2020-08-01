namespace Amazon.Integration.Interfaces
{
    public interface IEmailConfiguration : IAccessAmazonConfiguration
    {
        public string SenderAddress { get; }
        public string FrontEndUrl { get; }
        public string ActivateAccountRoute { get; }
        public string ForgotPasswordRoute { get; }
    }
}
