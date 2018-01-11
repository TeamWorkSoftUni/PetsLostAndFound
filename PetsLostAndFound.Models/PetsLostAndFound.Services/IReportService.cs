namespace PetsLostAndFound.Services
{
    using System;
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
            DateTime lostAndFound,
            string userId,
            IEnumerable<string> imagesLinksPost,
            double rewardSum,
            PostPetServiceModel pet,
            string content,
            PostLocationServiceModel location
           );

        GetReportDetailsModel FindById(int id);

        bool IsExists(int id);
    }
}
