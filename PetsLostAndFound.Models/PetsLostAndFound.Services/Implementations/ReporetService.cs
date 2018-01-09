﻿namespace PetsLostAndFound.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using PetsLostAndFound.Db;
    using PetsLostAndFound.Db.Models;
    using PetsLostAndFound.Db.Models.Enums;
    using PetsLostAndFound.Services.Models.Pets;
    using PetsLostAndFound.Services.Models.Reports;

    public class ReporetService : IReportService
    {
        private readonly PetsDbContext db;
        private readonly IMapper mapper;

        public ReporetService(PetsDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public IEnumerable<ReportListingServiceModel> AllListing()
            => this.db.Reports
                .OrderByDescending(p => p.Id)
                .ProjectTo<ReportListingServiceModel>()
                .ToList();

        public ReportListingServiceModel Create(
            StatusType statusType, 
            string userId, 
            string imagesLinksPost, 
            double rewardSum,
            Pet pet, 
            string content, 
            Location location)
        {
            var report = new Report
            {
                Status = statusType,
                UserId = userId,
                ImagesLinksPost = imagesLinksPost,
                RewardSum = rewardSum,
                Pet = pet,
                Content = content,
                Location = location,
                LostDate = DateTime.UtcNow.Date
            };

            this.db.Reports.Add(report);
            this.db.SaveChanges();

            return this.mapper.Map<ReportListingServiceModel>(report);
        }
    }
}
