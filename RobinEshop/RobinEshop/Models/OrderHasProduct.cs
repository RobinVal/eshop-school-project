using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobinEshop.Models
{
    public class OrderHasProduct
    {
        [Key]
        public int OrderHasProductId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public int Number { get; set; }
        public int PriceTotal { get; set; }
    }
}