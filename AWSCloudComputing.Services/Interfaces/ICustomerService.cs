using AWSCloudComputing.DataAccess;
using AWSCloudComputing.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWSCloudComputing.Services.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerResponse> GetCustomers();
    }
}
