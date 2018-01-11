namespace PetsLostAndFound.Services
{
    using PetsLostAndFound.Services.Models.Comments;
    using System.Collections.Generic;
    using PetsLostAndFound.Common;

    public interface ICommentService
    {
        ResponseMessage Create(int reportId, string content, string userId);

        IEnumerable<CommentsListingServiceModel> All (int reportId);

        bool IsExists(int id);

        ResponseMessage Remove(int commentId);
    }
}
