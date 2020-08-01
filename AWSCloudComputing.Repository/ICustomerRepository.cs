using AWSCloudComputing.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWSCloudComputing.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
    }
}
