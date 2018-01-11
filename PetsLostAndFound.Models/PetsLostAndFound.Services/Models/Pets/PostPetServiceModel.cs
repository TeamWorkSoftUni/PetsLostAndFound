namespace PetsLostAndFound.Services.Models.Pets
{
    using System.ComponentModel.DataAnnotations;

    public class PostPetServiceModel
    {
        public string PetType { get; set; }

        [Required]
        public string PetName { get; set; }

        public int Age { get; set; }

        public string RFID { get; set; }

        public string Description { get; set; }
    }
}
