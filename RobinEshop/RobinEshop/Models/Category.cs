﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RobinEshop.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}