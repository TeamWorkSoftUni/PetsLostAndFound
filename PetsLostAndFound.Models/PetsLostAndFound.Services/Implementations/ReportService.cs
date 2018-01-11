namespace PetsLostAndFound.Services.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using PetsLostAndFound.Db;
    using PetsLostAndFound.Db.Models;
    using PetsLostAndFound.Db.Models.Enums;
    using PetsLostAndFound.Services.Models.Reports;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using PetsLostAndFound.Common;
    using PetsLostAndFound.Services.Models.Locations;
    using PetsLostAndFound.Services.Models.Pets;

    public class ReportService : IReportService
    {
        private readonly PetsDbContext db;
        private readonly IMapper mapper;
        private readonly IPetService pet;
        private readonly ILocationSevices location;

        public ReportService(PetsDbContext db, IMapper mapper, IPetService pet, ILocationSevices location)
        {
            this.db = db;
            this.mapper = mapper;
            this.pet = pet;
            this.location = location;
        }

        public IEnumerable<ReportListingServiceModel> AllListing()
            => this.db.Reports
                .OrderByDescending(r => r.Id)
                .ProjectTo<ReportListingServiceModel>()
                .ToList();

        public ResponseMessage Create(
            string statusType,
            DateTime lostAndFound,
            string userId, 
            IEnumerable<string> imagesLinksPost, 
            double rewardSum,
            PostPetServiceModel petModel, 
            string content, 
            PostLocationServiceModel locationModel)
        {

            var status = (StatusType)Enum.Parse(typeof(StatusType), statusType, true);

            var petId = this.pet.Create(userId, petModel.PetType, petModel.PetName, petModel.Age, petModel.RFID, petModel.Description);

            var locationId = this.location.Create(locationModel.LocationAddress, locationModel.Latitude, locationModel.Longitude);

            var images = string.Join(" ", imagesLinksPost);

            var report = new Report
            {
                Status = status,
                UserId = userId,
                ImagesLinksPost = images,
                RewardSum = rewardSum,
                Content = content,
                LocationId = locationId,
                LostDate = lostAndFound,
                PetId = petId
            };

            this.db.Reports.Add(report);
            this.db.SaveChanges();

            return new ResponseMessage { Success = true, Message = "Report added", Report = report};
        }

        public GetReportDetailsModel FindById(int id)
        {
            var reportById = this.db.Reports
                .Where(r => r.Id == id)
                .ProjectTo<ReportDetailsServiceModel>()
                .FirstOrDefault();

            var status = reportById.StatusType.ToString();
            var images = reportById.ImagesLinksPost.Split(' ').ToArray();

            var reportToPost = new GetReportDetailsModel
            {
                Id = reportById.Id,
                StatusType = status,
                LostFoundDate = reportById.LostDate,
                Content = reportById.Content,
                Rfid = reportById.Rfid,
                RewardSum = reportById.RewardSum,
                UserId = reportById.UserId,
                Location = reportById.Location,
                TargetPet = reportById.Pet,
                TargetPetImagesId = images
            };

            return reportToPost;
        }

        public bool IsExists(int id)
            => this.db.Reports.Any(r => r.Id == id);
    }
}
