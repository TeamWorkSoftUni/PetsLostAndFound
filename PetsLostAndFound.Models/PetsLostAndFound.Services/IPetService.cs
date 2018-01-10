namespace PetsLostAndFound.Services
{
    using PetsLostAndFound.Services.Models.Pets;
    using System.Collections.Generic;

    public interface IPetService
    {
        IEnumerable<PetListingServiceModel> AllListing();

        PetListingServiceModel Create(
                string petType,
                string name,
                int age,
                string rfid,
                string imageLinks,
                string description, 
                string userId);
    }
}
