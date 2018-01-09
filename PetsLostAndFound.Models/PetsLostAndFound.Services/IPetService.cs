namespace PetsLostAndFound.Services
{
    using PetsLostAndFound.Db.Models.Enums;
    using PetsLostAndFound.Services.Models.Pets;
    using System.Collections.Generic;

    public interface IPetService
    {
        IEnumerable<PetListingServiceModel> AllListing();

        PetListingServiceModel Create(
                PetType petType,
                string name,
                int age,
                string rfid,
                string imageLinks,
                string description, 
                string userId);
    }
}
