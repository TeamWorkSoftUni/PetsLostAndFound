namespace PetsLostAndFound.Services
{
    using PetsLostAndFound.Services.Models.Pets;
    using System.Collections.Generic;

    public interface IPetService
    {
        IEnumerable<PetListingServiceModel> AllListing();

        int Create(
                string userId,
                string petType,
                string name,
                int age,
                string rfid,
                string description);
    }
}
