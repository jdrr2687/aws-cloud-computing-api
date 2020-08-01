using AWSCloudComputing.DataAccess;
using AWSCloudComputing.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWSCloudComputing.Services.Mappers
{
    public interface ICustomerMapper
    {
        CustomerResponse MapEntityToResponse(Customer customer);
        List<CustomerResponse> MapListEntityToListResponse(List<Customer> customers);
    }
}
