using AWSCloudComputing.DataAccess;
using AWSCloudComputing.Models;
using AWSCloudComputing.Repository;
using AWSCloudComputing.Services.Interfaces;
using AWSCloudComputing.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWSCloudComputing.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository CustomerRepository;
        private readonly ICustomerMapper CustomerMapper;
        public CustomerService(ICustomerRepository customerRepository, ICustomerMapper customerMapper)
        {
            CustomerRepository = customerRepository;
            CustomerMapper = customerMapper;
        }

        public List<CustomerResponse> GetCustomers()
        {
            var customers = CustomerRepository.GetCustomers();

            return CustomerMapper.MapListEntityToListResponse(customers);
        }
    }
}
