namespace PetsLostAndFound.Services
{
    using PetsLostAndFound.Db.Models;
    using PetsLostAndFound.Services.Models.Reports;
    using System.Collections.Generic;
    using PetsLostAndFound.Services.Models.Pets;

    public interface IReportService
    {
        IEnumerable<ReportListingServiceModel> AllListing();

        ReportListingServiceModel Create(
            string statusType,
            string userId,
            string imagesLinksPost,
            double rewardSum,
            PostPetServiceModel pet,
            string content,
            Location location
           );

        bool IsExist(int id);
    }
}
