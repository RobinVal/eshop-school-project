using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobinEshop.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }
        public string Image { get; set; }
        
        public ICollection<ArticleComment> Comments { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}