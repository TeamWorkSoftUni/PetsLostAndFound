namespace PetsLostAndFound.Services.Models.Reports
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using PetsLostAndFound.Common.Mapping;
    using PetsLostAndFound.Db.Models;
    using PetsLostAndFound.Db.Models.Enums;

    public class ReportListingServiceModel : IMapFrom<Report>
    {
        public int Id { get; set; }

        public StatusType Status { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public DateTime LostDate { get; set; }

        public string ImagesLinksPost { get; set; }

        public double? RewardSum { get; set; }

        public int PetId { get; set; }

        public Pet Pet { get; set; }

        public string Content { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }
    }
}
