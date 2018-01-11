namespace PetsLostAndFound.Services.Models.Reports
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using PetsLostAndFound.Common.Mapping;
    using PetsLostAndFound.Db.Models;
    using PetsLostAndFound.Db.Models.Enums;
    using PetsLostAndFound.Services.Models.Pets;

    public class ReportListingServiceModel : IMapFrom<Report>
    {
        public int Id { get; set; }

        public StatusType Status { get; set; }

        public string ImagesLinksPost { get; set; }

        public PetListingServiceModel Pet { get; set; }

    }
}
