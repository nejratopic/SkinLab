using System.ComponentModel.DataAnnotations;
using System;

namespace RS1_2024_25.API.Data.Models.Auth
{
    public class MyAppUser
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }  
        public string City { get; set; }  
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsManager { get; set; }

    }
}
