namespace PetsLostAndFound.Services.Models.Pets
{
    using PetsLostAndFound.Common.Mapping;
    using PetsLostAndFound.Db.Models;
    using PetsLostAndFound.Db.Models.Enums;
    using System;
    using System.Collections.Generic;

    public class PetListingServiceModel : IMapFrom<Pet>
    {
        public int Id { get; set; }

        public PetType PetType { get; set; }
        
        public string Name { get; set; }

        public int Age { get; set; }

        public string RFID { get; set; }

        public string ImageLinks { get; set; }

        public string PetDescription { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string UserId { get; set; }
        
        public User User { get; set; }

        public ICollection<Report> Reports { get; set; }
    }
}
