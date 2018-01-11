namespace PetsLostAndFound.Web.Models.Reports
{
    using Services.Models.Locations;
    using Services.Models.Pets;
    using System;
    using System.Collections.Generic;

    public class PostCreateReportRequestModel
    {
        public string StatusType { get; set; }

        public DateTime LostFoundDate { get; set; }

        public string Content { get; set; }

        public string Rfid { get; set; }

        public double RewardSum { get; set; }

        public PostLocationServiceModel Location { get; set; }

        public string UserId { get; set; }

        public PostPetServiceModel TargetPet { get; set; }

        public IEnumerable<string> TargetPetImagesId { get; set; }
    }
}