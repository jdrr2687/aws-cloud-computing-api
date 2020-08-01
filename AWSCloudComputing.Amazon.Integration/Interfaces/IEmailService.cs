using Amazon.Integration.Models;
using System.Threading.Tasks;

namespace Amazon.Integration.Interfaces
{
    public interface IEmailService
    {
        Task<EmailResponse> SendEmail(EmailRequest emailRequest);
        Task<EmailResponse> SendEmailWithTemplate(EmailTemplateRequest emailWithTemplateRequest);
        string GetFrontEndUrl();
        string GetForgotPasswordRoute();
    }
}
