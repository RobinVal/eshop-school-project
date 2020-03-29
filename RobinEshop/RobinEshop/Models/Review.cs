using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobinEshop.Models
{
    public class Review
    {
        [Key]    
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } 
        [Required]
        public int Stars { get; set; } 
        [Required]
        public string Content { get; set; }
    }
}