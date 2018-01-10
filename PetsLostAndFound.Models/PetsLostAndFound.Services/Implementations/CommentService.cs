namespace PetsLostAndFound.Services.Implementations
{
    using System.Collections.Generic;
    using PetsLostAndFound.Db;
    using PetsLostAndFound.Db.Models;
    using PetsLostAndFound.Services.Models.Comments;
    using System.Linq;
    using AutoMapper.QueryableExtensions;

    public class CommentService : ICommentService
    {
        private readonly PetsDbContext db;

        public CommentService(PetsDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CommentsListingServiceModel> All(int reportId)
        {
            var report = this.db.Reports.Find(reportId);

            if (report == null)
            {
                return null;
            }

            return this.db.Comments
                .Where(c => c.PostId == reportId)
                .ProjectTo<CommentsListingServiceModel>()
                .ToList();
        }

        public ResponseMessage Create(int reportId, string content, string userId)
        {
            var report = this.db.Reports.Find(reportId);
            var user = this.db.Users.Find(userId);

            if (report == null || user == null)
            {
                return new ResponseMessage { Success = false, Message = "Comment Not Added", Comment = content };
            }

            var comment = new Comment
            {
                Content = content,
                PostId = reportId,
                UserId = userId
            };

            this.db.Comments.Add(comment);
            this.db.SaveChanges();

            return new ResponseMessage { Success = true, Message = "Comment added successfully", Comment = content };
        }

        public bool IsExists(int id)
            => this.db.Comments.Any(c => c.Id == id);

        public ResponseMessage Remove(int commentId)
        {
            var comment = this.db.Comments.Find(commentId);

            this.db.Remove(comment);
            this.db.SaveChanges();

            return new ResponseMessage { Success = true, Message = "Comment removed", Comment = comment.Content };
        }
    }
}
