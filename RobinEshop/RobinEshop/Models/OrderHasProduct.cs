using System.Collections.Generic;
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
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        [Column(TypeName = "decimal(13,2)")]
        public decimal Number { get; set; }
        [Column(TypeName = "decimal(13,2)")]
        public decimal PriceTotal { get; set; }

    }
}