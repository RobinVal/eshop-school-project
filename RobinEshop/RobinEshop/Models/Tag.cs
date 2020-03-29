using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobinEshop.Models
{
    public class Tag
    {
    [Key]
    public int TagId { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    [Required]
    public string Name { get; set; }
    }
}