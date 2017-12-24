namespace PetsLostAndFound.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Content { get; set; }

        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        
        public int PostId { get; set; }
        [Required]
        public Report Post { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}