using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobinEshop.Models
{
    public class Tag
    {
    [Key]
    public int TagId { get; set; }
    [ForeignKey("ProductId")] 
    public Product Product { get; set; }
    [Required]
    public string Name { get; set; }
    }
}