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
    using PetsLostAndFound.Services.Models.Pets;

    public class ReportService : IReportService
    {
        private readonly PetsDbContext db;
        private readonly IMapper mapper;
        private readonly IPetService pet;

        public ReportService(PetsDbContext db, IMapper mapper, IPetService pet)
        {
            this.db = db;
            this.mapper = mapper;
            this.pet = pet;
        }

        public IEnumerable<ReportListingServiceModel> AllListing()
            => this.db.Reports
                .OrderByDescending(p => p.Id)
                .ProjectTo<ReportListingServiceModel>()
                .ToList();

        public ReportListingServiceModel Create(
            string statusType, 
            string userId, 
            string imagesLinksPost, 
            double rewardSum,
            PostPetServiceModel petModel, 
            string content, 
            Location location)
        {
            var status = (StatusType)Enum.Parse(typeof(StatusType), statusType, true);

            this.pet.Create(petModel.PetType, petModel.PetName, petModel.Age, petModel.RFID, petModel.Description);

            var report = new Report
            {
                Status = status,
                UserId = userId,
                ImagesLinksPost = imagesLinksPost,
                RewardSum = rewardSum,
                Content = content,
                Location = location,
                LostDate = DateTime.UtcNow.Date
            };

            this.db.Reports.Add(report);
            this.db.SaveChanges();

            return this.mapper.Map<ReportListingServiceModel>(report);
        }

        public bool IsExist(int id)
            => this.db.Reports.Any(r => r.Id == id);
    }
}
