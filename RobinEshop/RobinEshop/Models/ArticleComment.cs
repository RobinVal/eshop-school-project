using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobinEshop.Models
{
    public class ArticleComment
    {
        [Key]
        public int ArticleCommentId { get; set; }
        [ForeignKey("ArticleID")]
        public Article Article { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string Content { get; set; }
    }
}