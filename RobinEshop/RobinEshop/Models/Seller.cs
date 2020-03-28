using System.ComponentModel.DataAnnotations;

namespace RobinEshop.Models
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}