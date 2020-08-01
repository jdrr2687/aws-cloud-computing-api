using AWSCloudComputing.DataAccess;
using AWSCloudComputing.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWSCloudComputing.Services.Mappers
{
    public class CustomerMapper : ICustomerMapper
    {
        public CustomerResponse MapEntityToResponse(Customer customer)
        {
            return new CustomerResponse()
            {
                Id = customer.Id,
                Nombre = customer.Nombre
            };
        }

        public List<CustomerResponse> MapListEntityToListResponse(List<Customer> customers)
        {
            var customersDto = new List<CustomerResponse>();

            foreach (Customer c in customers)
            {
                customersDto.Add(MapEntityToResponse(c));
            }

            return customersDto;
        }
    }
}
