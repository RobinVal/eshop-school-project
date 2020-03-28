using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobinEshop.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [ForeignKey("UserDetailId")]
        public UserDetail UserDetail { get; set; }
        [Required]
        public string Email { get; set;}
        [Required]
        public string PasswordHash { get; set; }
        [Required] 
        public UserRights Rights { get; set; } = UserRights.User;
        
        public enum  UserRights
        {
            User,
            Admin,
        }
    }
}