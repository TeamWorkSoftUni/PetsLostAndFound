namespace PetsLostAndFound.Services
{
    using PetsLostAndFound.Db.Models;
    using PetsLostAndFound.Db.Models.Enums;
    using PetsLostAndFound.Services.Models.Reports;
    using System.Collections.Generic;

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
