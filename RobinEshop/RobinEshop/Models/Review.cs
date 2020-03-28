using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobinEshop.Models
{
    public class Review
    {
        [Key]    
        public int ReviewId { get; set; }
        [ForeignKey("UserId")] 
        public User User { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; } 
        [Required]
        public int Stars { get; set; } 
        [Required]
        public string Content { get; set; }
    }
}