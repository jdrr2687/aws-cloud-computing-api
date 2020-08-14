using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Integration.Interfaces;
using AWSCloudComputing.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaberApi.Servicios.Generales.Services.Interfaces;

namespace AWSCloudComputing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmazonController : ControllerBase
    {
        private readonly IEmailService EmailService;
        private readonly IUploadFileService UploadFileService;
        public AmazonController(IEmailService emailService, IUploadFileService uploadFileService)
        {
            EmailService = emailService;
            UploadFileService = uploadFileService;
        }

      
        [HttpPost]
        [Route("Email")]
        public IActionResult SendEmail([FromBody] EmailRequest emailRequest)
        {
            EmailService.SendEmail(new Amazon.Integration.Models.EmailRequest()
            {
                HtmlBody = @"<p>"+ emailRequest.Message+ "</p>",
                Subject = emailRequest.Subject,
                Receivers = new List<string>() {
                    emailRequest.SendedEmail
                },
                TextBody = emailRequest.Message
            });

            return Ok();
        }

      
        [HttpPost]
        [Route("Upload")]
        public async Task<ActionResult<List<string>>> UploadFile(List<IFormFile> files)
        {
            return Ok(await UploadFileService.UploadFile(files));
        }
    }
}