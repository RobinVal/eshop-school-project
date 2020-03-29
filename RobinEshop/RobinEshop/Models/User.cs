using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobinEshop.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public int UserDetailId { get; set; }
        public UserDetail UserDetail { get; set; }
        [Required]
        public string Email { get; set;}
        [Required]
        public string PasswordHash { get; set; }
        [Required] 
        public UserRights Rights { get; set; } = UserRights.User;

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Article> Articles { get; set; }
        public enum  UserRights
        {
            User,
            Admin,
        }
    }
}