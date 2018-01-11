namespace PetsLostAndFound.Services.Models.Reports
{
    using Common.Mapping;
    using Db.Models;
    using Db.Models.Enums;
    using Services.Models.Locations;
    using Services.Models.Pets;
    using System;

    public class ReportDetailsServiceModel : IMapFrom<Report>
    {
        public int Id { get; set; }

        public StatusType StatusType { get; set; }

        public DateTime LostDate { get; set; }

        public string Content { get; set; }

        public string Rfid { get; set; }

        public double RewardSum { get; set; }

        public PostLocationServiceModel Location { get; set; }

        public string UserId { get; set; }

        public PostPetServiceModel Pet { get; set; }

        public string ImagesLinksPost { get; set; }
    }
}
