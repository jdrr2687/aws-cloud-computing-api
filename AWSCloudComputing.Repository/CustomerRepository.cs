using AWSCloudComputing.DataAccess;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AWSCloudComputing.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConfiguration Configuration;

        public CustomerRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected string ConnectionString
        {
            get { return Configuration.GetConnectionString("Default"); }
        }

        public List<Customer> GetCustomers()
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                return conn.Query<Customer>("Select * from cliente").AsList();
            }
        }
    }
}
