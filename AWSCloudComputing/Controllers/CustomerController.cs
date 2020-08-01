using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSCloudComputing.Models;
using AWSCloudComputing.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWSCloudComputing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService CustomerService;

        public CustomerController(ICustomerService customerService)
        {
            CustomerService = customerService;
        }

        [HttpGet]
        public ActionResult<List<CustomerResponse>> GetAllCustomers()
        {
            return new OkObjectResult(CustomerService.GetCustomers());
        }
    }
}