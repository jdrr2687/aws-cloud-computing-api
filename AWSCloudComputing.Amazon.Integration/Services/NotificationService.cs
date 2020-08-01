using Amazon.Integration.Interfaces;
using Amazon.Integration.Models;
using Amazon.Integration.Utils;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using System.Collections.Generic;

namespace Amazon.Integration.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ISNSConfiguration SNSConfiguration;

        public NotificationService(ISNSConfiguration sNSConfiguration)
        {
            SNSConfiguration = sNSConfiguration;
        }

        public NotificationResponse Send(NotificationRequest notificationRequest)
        {
            NotificationResponse notificationResponse = new NotificationResponse();
            using (var snsService = new AmazonSimpleNotificationServiceClient(SNSConfiguration.AccessKeyId, SNSConfiguration.AccessSecretKey, SNSConfiguration.Region))
            {
                var attributes = new Dictionary<string, MessageAttributeValue>();
                attributes.Add("AWS.SNS.SMS.SenderID", new MessageAttributeValue() { StringValue = notificationRequest.SenderId, DataType = "String" });
                attributes.Add("AWS.SNS.SMS.SMSType", new MessageAttributeValue() { StringValue = notificationRequest.Type.GetDescription(), DataType = "String" });

                var request = new PublishRequest() {
                    PhoneNumber = $"+{notificationRequest.PhoneNumber}",
                     Message = notificationRequest.TextMessage,
                    MessageAttributes = attributes
                };

                var result = snsService.PublishAsync(request).Result;
                if (result.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    notificationResponse.IsValid = true;
                else
                {
                    notificationResponse.Errors.Add("SMS failed!");
                    notificationResponse.IsValid = false;
                }
            }

            return notificationResponse;
        }
    }
}
