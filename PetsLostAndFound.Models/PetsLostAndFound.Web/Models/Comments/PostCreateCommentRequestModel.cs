namespace PetsLostAndFound.Web.Models.Comments
{
    using System.ComponentModel.DataAnnotations;

    public class PostCreateCommentRequestModel
    {
        public int ReportId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
