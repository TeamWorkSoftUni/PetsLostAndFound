namespace PetsLostAndFound.Services.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using PetsLostAndFound.Db;
    using PetsLostAndFound.Db.Models;
    using PetsLostAndFound.Db.Models.Enums;
    using PetsLostAndFound.Services.Models.Pets;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PetService : IPetService
    {
        private readonly PetsDbContext db;
        private readonly IMapper mapper;

        public PetService(PetsDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public IEnumerable<PetListingServiceModel> AllListing()
            => this.db.Pets
            .OrderByDescending(p => p.Id)
            .ProjectTo<PetListingServiceModel>()
            .ToList();

        public PetListingServiceModel Create(string petType, string name, int age, string rfid, string imageLinks, string description, string userId)
        {
            // CHECK FOR USER 

            var current = (PetType) Enum.Parse(typeof(PetType), petType, true);

            var pet = new Pet
            {
                PetType = current,
                Name = name,
                Age = age,
                RFID = rfid,
                ImageLinks = imageLinks,
                PetDescription = description,
                UserId = userId,
                RegistrationDate = DateTime.UtcNow.Date
            };

            this.db.Pets.Add(pet);
            this.db.SaveChanges();

            return this.mapper.Map<PetListingServiceModel>(pet);
        }
    }
}
