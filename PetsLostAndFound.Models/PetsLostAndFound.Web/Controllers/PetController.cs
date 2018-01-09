namespace PetsLostAndFound.Web.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using PetsLostAndFound.Services;
  using PetsLostAndFound.Web.Models.Pets;
  
  public class PetController : BaseController
  {
    private readonly IPetService pets;

    public PetController(IPetService pets)
    {
      this.pets = pets;
    }

    [HttpPost]
    public IActionResult Create([FromBody] PostCreatePetRequestModel model)
    {
      if (!ModelState.IsValid)
      {
        return this.BadRequest();
      }

      var result = this.pets.Create(
          model.PetType, 
          model.Name, 
          model.Age, 
          model.RFID, 
          model.ImageLinks, 
          model.PetDescription, 
          model.UserId);

      return this.Ok(result);
    }
  }
}
