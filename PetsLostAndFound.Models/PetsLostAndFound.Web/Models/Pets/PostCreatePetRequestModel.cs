namespace PetsLostAndFound.Web.Models.Pets
{
    using System.ComponentModel.DataAnnotations;

    public class PostCreatePetRequestModel
  {

    public string PetType { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int Age { get; set; }

    public string RFID { get; set; }

    [Required]
    public string ImageLinks { get; set; }

    [Required]
    public string PetDescription { get; set; }

    public string UserId { get; set; }
  }
}
