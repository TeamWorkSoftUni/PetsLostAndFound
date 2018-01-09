namespace PetsLostAndFound.Web.Models.Pets
{
  using PetsLostAndFound.Db.Models.Enums;
  using System.ComponentModel.DataAnnotations;

  public class PostCreatePetRequestModel
  {

    public PetType PetType { get; set; }

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
