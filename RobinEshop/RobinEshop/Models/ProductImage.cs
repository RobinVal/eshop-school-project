using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobinEshop.Models
{
    public class ProductImage
    {
    [Key]
    public int ProductImageId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; }
    public string Image { get; set; }
    }
}