using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RobinEshop.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserDetailId { get; set; }
        public UserDetail UserDetail { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ContactEmail { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public ICollection<OrderHasProduct> OrderHasProducts { get; set; }
    }
}