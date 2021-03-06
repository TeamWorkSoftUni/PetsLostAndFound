﻿namespace PetsLostAndFound.Services.Models.Pets
{
    using PetsLostAndFound.Common.Mapping;
    using PetsLostAndFound.Db.Models;
    using PetsLostAndFound.Db.Models.Enums;

    public class PetListingServiceModel : IMapFrom<Pet>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public PetType PetType { get; set; }
    }
}
