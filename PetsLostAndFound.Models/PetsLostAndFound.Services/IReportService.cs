namespace PetsLostAndFound.Services
{
    using Models.Reports;
    using System.Collections.Generic;
    using Models.Locations;
    using Models.Pets;
    using PetsLostAndFound.Common;

    public interface IReportService
    {
        IEnumerable<ReportListingServiceModel> AllListing();

        ResponseMessage Create(
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
