using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobinEshop.Models
{
    public class ProductImage
    {
    [Key]
    public int ProductImageId { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    [Required]
    public string Image { get; set; }
    }
}