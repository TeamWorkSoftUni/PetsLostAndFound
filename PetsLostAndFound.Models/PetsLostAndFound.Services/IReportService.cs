namespace PetsLostAndFound.Services
{
    using Models.Reports;
    using System.Collections.Generic;
    using Models.Locations;
    using Models.Pets;

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
            PostLocationServiceModel location
           );

        bool IsExist(int id);
    }
}
