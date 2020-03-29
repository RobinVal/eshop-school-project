using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobinEshop.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        [Required]
        public string Name { get; set; }    
        [Required]
        public string Description { get; set; }
        [Required]
        public int Number { get; set; }    
        [Required]
        [Column(TypeName = "decimal(13,2)")]
        public decimal Price { get; set; }     
        [Column(TypeName = "decimal(13,2)")]
        public decimal Sale { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<ProductImage> Images { get; set; }
    }
}