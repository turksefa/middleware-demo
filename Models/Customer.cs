using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware.Models
{
    public class Customer
    {
        public required string CustomerID { get; set; }
        public required string CompanyName { get; set; }
        public string? City { get; set; }
    }
}