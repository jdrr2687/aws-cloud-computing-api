using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Amazon.Integration.Interfaces;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Integration.Models;

namespace Amazon.Integration.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration EmailConfiguration;

        public EmailService(IEmailConfiguration emailConfiguration)
        {
            EmailConfiguration = emailConfiguration;
        }

        public string GetFrontEndUrl()
        {
            return EmailConfiguration.FrontEndUrl;
        }

        public string GetForgotPasswordRoute()
        {
            return EmailConfiguration.ForgotPasswordRoute;
        }

        public async Task<EmailResponse> SendEmail(EmailRequest emailRequest)
        {
            EmailResponse emailResponse = new EmailResponse();

            using var client = new AmazonSimpleEmailServiceClient(EmailConfiguration.AccessKeyId, EmailConfiguration.AccessSecretKey, RegionEndpoint.USEast2);

            var sendRequest = new SendEmailRequest
            {
                Source = EmailConfiguration.SenderAddress,
                Destination = new Destination
                {
                    ToAddresses = emailRequest.Receivers
                },
                Message = new Message
                {
                    Subject = new Content(emailRequest.Subject),
                    Body = new Body
                    {
                        Html = new Content
                        {
                            Charset = "UTF-8",
                            Data = emailRequest.HtmlBody
                        },
                        Text = new Content
                        {
                            Charset = "UTF-8",
                            Data = emailRequest.TextBody
                        }
                    }
                }
            };
            try
            {
                 await client.SendEmailAsync(sendRequest);
                 emailResponse.Success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("The email was not sent.");
                Console.WriteLine("Error message: " + ex.Message);
                emailResponse.Success = false;
            }
            finally
            {
                client.Dispose();
            }

            return emailResponse;
        }

        public async Task<EmailResponse> SendEmailWithTemplate(EmailTemplateRequest emailWithTemplateRequest)
        {
            EmailResponse emailResponse = new EmailResponse();

            using var client = new AmazonSimpleEmailServiceClient(EmailConfiguration.AccessKeyId, EmailConfiguration.AccessSecretKey, RegionEndpoint.USEast1);

            var sendRequest = new SendTemplatedEmailRequest
            {
                Source = EmailConfiguration.SenderAddress,
                Destination = new Destination
                {
                    ToAddresses = emailWithTemplateRequest.Receivers
                },
                Template = emailWithTemplateRequest.Template,
                TemplateData = JsonSerializer.Serialize(emailWithTemplateRequest.Data)
            };
            try
            {
                await client.SendTemplatedEmailAsync(sendRequest);
                emailResponse.Success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("The email was not sent.");
                Console.WriteLine("Error message: " + ex.Message);
                emailResponse.Success = false;
            }

            client.Dispose();

            return emailResponse;
        }
    }
}
