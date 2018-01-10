namespace PetsLostAndFound.Services.Models.Comments
{
    using AutoMapper;
    using PetsLostAndFound.Common.Mapping;
    using PetsLostAndFound.Db.Models;

    public class CommentsListingServiceModel : IMapFrom<Comment>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Username { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Comment, CommentsListingServiceModel>()
                .ForMember(c => c.Username, cfg => cfg.MapFrom(c => c.User.UserName));
        }
    }
}
