using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RobinEshop.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("UserDetailId")]
        public UserDetail UserDetail { get; set; }
    }
}