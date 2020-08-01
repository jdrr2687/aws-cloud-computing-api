using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWSCloudComputing.DataAccess
{
    [Table("Cliente")]
    public class Customer
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
