using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

// Order model created for the orders table in the database. Set up to store the information from the customer to the database

namespace Bookstore.Models
{
    public class Order
    {
        [Key]
        [BindNever]
        public int OrderId { get; set; }

        [BindNever]
        public ICollection<CartLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Enter Your First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter Your Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter a Valid Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Your Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter Your Address")]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Enter the City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter the State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Enter the Zip Code")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Enter the Country")]
        public string Country { get; set; }

        [BindNever]
        public bool OrderReceived { get; set; }
    }
}
