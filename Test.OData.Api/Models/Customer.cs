using System;
using System.ComponentModel.DataAnnotations;

namespace Test.OData.Api.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        [Key]
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}