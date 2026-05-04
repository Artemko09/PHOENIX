using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PHOENIX.Models
{
    public class News
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual ApplicationUser? Author { get; set; }
    }
}
