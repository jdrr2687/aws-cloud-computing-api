using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Integration.Interfaces;
using AWSCloudComputing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWSCloudComputing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmazonController : ControllerBase
    {
        private readonly IEmailService EmailService;

        public AmazonController(IEmailService emailService)
        {
            EmailService = emailService;
        }

        [HttpPost]
        [Route("Email")]
        public IActionResult SendEmail([FromBody] EmailRequest emailRequest)
        {

            EmailService.SendEmail(new Amazon.Integration.Models.EmailRequest()
            {
                HtmlBody = @"<h1>"+ emailRequest.Message+ "</h1>",
                Subject = "Envio de correo",
                Receivers = new List<string>() {
                    emailRequest.SendedEmail
                },
                TextBody = emailRequest.Message
            });

            return Ok();
        }
    }
}