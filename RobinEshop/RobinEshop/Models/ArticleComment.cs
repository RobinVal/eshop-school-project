using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobinEshop.Models
{
    public class ArticleComment
    {
        [Key]
        public int ArticleCommentId { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
    }
}