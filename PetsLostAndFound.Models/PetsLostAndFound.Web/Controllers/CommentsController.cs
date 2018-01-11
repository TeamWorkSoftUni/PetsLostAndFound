namespace PetsLostAndFound.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetsLostAndFound.Services;
    using PetsLostAndFound.Web.Models.Comments;

    public class CommentsController : BaseController
    {
        private readonly ICommentService comments;
        private readonly IReportService reports;

        public CommentsController(ICommentService comments, IReportService reports)
        {
            this.comments = comments;
            this.reports = reports;
        }

        [HttpPost]
        public IActionResult Create([FromBody] PostCreateCommentRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var message = this.comments.Create(model.ReportId, model.Content, model.UserId);

            return this.Ok(message);
        }

        [HttpGet("{id}")]
        public IActionResult All(int reportId)
        {
            if (!this.reports.IsExists(reportId))
            {
                return BadRequest();
            }

            var comments = this.comments.All(reportId);

            return this.Ok(comments);
        }

        [HttpPost("{id}")]
        public IActionResult Remove(int commentId)
        {
            if (!this.comments.IsExists(commentId))
            {
                return BadRequest();
            }

            var message = this.comments.Remove(commentId);

            return this.Ok(message);
        }
    }
}
