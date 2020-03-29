using System.ComponentModel.DataAnnotations;

namespace RobinEshop.Models
{
    public class UserDetail
    {
        [Key]
        public int UserDetailId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ContactEmail { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string ZipCode { get; set; }

        public User User { get; set; }
    }
}