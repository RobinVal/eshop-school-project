using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobinEshop.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [ForeignKey("SellerID")]
        public Seller Seller { get; set; }
        [Required]
        public string Name { get; set; }    
        [Required]
        public string Description { get; set; }
        [Required]
        public int Number { get; set; }    
        [Required]
        public int Price { get; set; }     
        public int Sale { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}