namespace PetsLostAndFound.Services
{
    using System.Collections.Generic;
    using PetsLostAndFound.Db.Models;
    using PetsLostAndFound.Db.Models.Enums;
    using PetsLostAndFound.Services.Models.Pets;
    using PetsLostAndFound.Services.Models.Reports;

    public interface IReportService
    {
        IEnumerable<ReportListingServiceModel> AllListing();

        ReportListingServiceModel Create(
            StatusType statusType,
            string userId,
            string imagesLinksPost,
            double rewardSum,
            Pet pet,
            string content,
            Location location
           );
    }
}
