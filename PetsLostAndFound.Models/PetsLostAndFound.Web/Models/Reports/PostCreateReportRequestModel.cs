namespace PetsLostAndFound.Web.Models.Reports
{
    using Services.Models.Locations;
    using Services.Models.Pets;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PostCreateReportRequestModel
    {
        [Required]
        public string StatusType { get; set; }

        [Required]
        public DateTime LostFoundDate { get; set; }

        public string Content { get; set; }

        public string Rfid { get; set; }

        public double RewardSum { get; set; }

        [Required]
        public PostLocationServiceModel Location { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public PostPetServiceModel TargetPet { get; set; }

        public IEnumerable<string> TargetPetImagesId { get; set; }
    }
}