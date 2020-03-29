using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobinEshop.Models
{
    public class OrderHasProduct
    {
        [Key]
        public int OrderHasProductId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Required]
        public int Number { get; set; }
        public int PriceTotal { get; set; }
    }
}