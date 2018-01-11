namespace PetsLostAndFound.Services.Models.Reports
{

    using System;
    using System.Collections.Generic;
    using PetsLostAndFound.Services.Models.Locations;
    using PetsLostAndFound.Services.Models.Pets;

    public class GetReportDetailsModel
    {
        public int Id { get; set; }

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
